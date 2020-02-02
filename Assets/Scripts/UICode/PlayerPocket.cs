using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPocket : MonoBehaviour
{
    private static ulong money;

    public static ulong Money
    {
        get => money;
        set
        {
            if (money != value)
            {
                money = value;
            }

        }
    }

    void Awake()
    {
        Money = 0;
    }

}
