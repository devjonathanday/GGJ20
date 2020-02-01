using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPocket : MonoBehaviour
{

    private static float money;

    public static float Money
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

    // Start is called before the first frame update
    void Awake()
    {
        Money = 0;
    }

}
