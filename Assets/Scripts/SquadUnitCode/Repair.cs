using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public float RepairRadius;
    public float RepairRate = 1;
    public float RestoreAmmount = 1;
    public LayerMask mask;

    private bool repairFlag = false;
    public bool RepairFlag
    {
        get => repairFlag;
        set
        {
            repairFlag = value;
            if (value == true)
            {
                StartCoroutine(RepairProcess());
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
        while (repairFlag)
        {
            timer += Time.deltaTime;
            RaycastHit hit;

            if (timer > RepairRate)
            {
                if (Physics.SphereCast(transform.position, RepairRadius, Vector3.zero, out hit, 0, mask))
                {
                    hit.collider.GetComponent<MoneyMachine>().Health += RestoreAmmount;
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

}
