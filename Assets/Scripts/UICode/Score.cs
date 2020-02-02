using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public string MoneyLaundered;
    public TextMeshProUGUI uGUI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoneyLaundered = "SCORE: " + PlayerPocket.Money.ToString();
        uGUI.text = MoneyLaundered;
    }
}
