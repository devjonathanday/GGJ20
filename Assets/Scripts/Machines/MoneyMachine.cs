using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMachine : MonoBehaviour
{
    public float Health = 10;
    public ulong Income = 10;
    public ulong Cost;
    public float IncomeTickRate = 1;
    public ParticleSystem smokeEffect;
    bool broken;
    public bool Broken
    {
        get { return broken; }
        set
        {
            broken = value;
            if (broken) smokeEffect.Play();
            else smokeEffect.Stop();
        }
    }
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > IncomeTickRate)
        {
            PlayerPocket.Money += Income;
            timer = 0;
        }
    }
}
