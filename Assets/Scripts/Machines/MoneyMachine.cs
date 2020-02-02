using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMachine : MonoBehaviour
{
    public float Health = 10;
    public ulong Income = 10;
    public ulong Cost;
    public float IncomeTickRate = 1;
    public GameObject workingEffects;
    public GameObject brokenEffects;
    bool broken;
    bool lossContributed = false;
    public bool Broken
    {
        get { return broken; }
        set
        {
            broken = value;
            if (broken) 
            {
                brokenEffects.SetActive(true);
                workingEffects.SetActive(false);
                if(lossContributed == false)
                {
                    LossConditions.MachinesLeft -= 1;
                    lossContributed = true;
                }

            }
            else
            {
                brokenEffects.SetActive(false);
                workingEffects.SetActive(true);
                if (lossContributed == true)
                {
                    LossConditions.MachinesLeft += 1;
                    lossContributed = false;
                }
            }

        }
    }
    float timer = 0;

    private void Start()
    {
        LossConditions.MachinesLeft += 1;
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > IncomeTickRate)
        {
            if(!broken) PlayerPocket.Money += Income;
            timer = 0;
        }

        ////TODO remove this
        //if(Input.GetKeyDown(KeyCode.K))
        //{
        //    Health = 0;
        //    Broken = true;
        //}
    }
}
