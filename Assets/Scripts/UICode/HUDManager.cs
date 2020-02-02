using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI unitsRemainingText;
    void Update()
    {
        unitsRemainingText.text = "Units: " + LossConditions.WorkersLeft + "/9";
        moneyText.text = "$" + PlayerPocket.Money;
    }
}