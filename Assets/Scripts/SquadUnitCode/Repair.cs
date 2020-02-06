using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public float RepairRadius;
    public float RepairRate = 1;
    public float RestoreAmmount = 1;
    public LayerMask mask;
    public Animator animator;

    private bool repairingIsOn = false;

    private bool repairFlag = false;
    public bool RepairFlag
    {
        get => repairFlag;
        set
        {
            repairFlag = value;
            if (value == true)
            {
                if (repairingIsOn == false)
                {
                    StartCoroutine(RepairProcess());
                }
                else
                {
                    StopCoroutine(RepairProcess());
                    if (value == true)
                    {
                        animator.SetBool("Fixing", true);
                        StartCoroutine(RepairProcess());

                    }
                }
               
            }
        }
    }




    float timer = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }




    public IEnumerator RepairProcess()
    {
        repairingIsOn = true;
        while (repairFlag)
        {
            List<Collider> hits;
            hits = new List<Collider>();
            hits.AddRange(Physics.OverlapSphere(transform.position, RepairRadius, mask));
            timer += Time.deltaTime;

            if (timer > RepairRate)
            {
                if (hits.Capacity != 0)
                {
                    foreach (Collider item in hits)
                    {
                        if (Vector3.Distance(transform.position, item.transform.position) > RepairRadius * 2)
                        {
                            hits.Remove(item);
                        }
                        else
                        {
                            MoneyMachine temp = item.GetComponent<MoneyMachine>();
                            temp.Health += RestoreAmmount;
                            if (temp.Broken && temp.Health > 10)
                            {
                                temp.Broken = false;
                            }

                            timer = 0;
                            Debug.Log("BoogieBoi");
                        }
                    }
                }
                else
                {
                    repairingIsOn = false;
                    RepairFlag = false;
                    Debug.Log("exit");
                    animator.SetBool("Fixing", false);
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

}
