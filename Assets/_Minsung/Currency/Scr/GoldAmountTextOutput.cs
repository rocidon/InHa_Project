using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; 


public class GoldAmountTextOutput : MonoBehaviour
{
    public TextMeshProUGUI text;
    public CurrencyData goldData;


    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (text != null && goldData != null)
        {
            text.text = goldData.goldAmount.ToString();
        }
        else
        {
            Debug.Log("Not \"text\" or \"goldData\"");

        }
    }
}