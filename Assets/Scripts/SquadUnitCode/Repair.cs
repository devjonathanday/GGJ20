using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
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

}
