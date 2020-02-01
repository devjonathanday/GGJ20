using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    void Update()
    {
        moneyText.text = "$" + PlayerPocket.Money;
    }
}