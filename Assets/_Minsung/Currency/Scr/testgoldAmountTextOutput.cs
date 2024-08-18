using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; 


public class testgoldAmountTextOutput : MonoBehaviour
{
    public TextMeshProUGUI text;

    public CurrencyData test;


    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (text != null && test != null)
        {
            text.text = test.curGoldAmount.ToString();
        }
        else
        {
            Debug.Log("Not \"text\" or \"testData\"");

        }
    }
}