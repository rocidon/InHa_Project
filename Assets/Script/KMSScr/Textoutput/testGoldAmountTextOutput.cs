using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; 


public class testGoldAmountTextOutput : MonoBehaviour
{
    public TextMeshProUGUI text;

    public CurrencyData currencyData;


    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (text != null && currencyData != null)
        {
            text.text = currencyData.curGoldAmount.ToString();
        }
        else
        {
            Debug.Log("Not \"text\" or \"testData\"");

        }
    }
}