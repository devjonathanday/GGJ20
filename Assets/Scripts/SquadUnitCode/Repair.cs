using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public float RepairRadius;
    public LayerMask mask;

    private bool repairFlag = false;
    public bool RepairFlag
    {
        get => repairFlag;
        set
        {
            repairFlag = value;
        }
    }


    public float RestoreAmmount = 1;

    float timer = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator RepairProcess()
    {
        while (repairFlag)
        {
            RaycastHit hit;
            Physics.SphereCast(transform.position, RepairRadius, Vector3.zero, out hit, 0, mask);
            yield return new WaitForFixedUpdate();
        }
    }

}
