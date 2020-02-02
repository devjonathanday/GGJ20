using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossConditions : MonoBehaviour
{
    public static int WorkersLeft;
    public static int MachinesLeft;

    public GameObject LossScreenCanvas;

    private void Awake()
    {

        WorkersLeft = 0;
        MachinesLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (WorkersLeft <= 0 || MachinesLeft <= 0)
        {
            LossScreenCanvas.SetActive(true);
        }
    }
}
