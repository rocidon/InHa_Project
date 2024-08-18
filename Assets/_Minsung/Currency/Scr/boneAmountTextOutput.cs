using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; 


public class boneAmountTextOutput : MonoBehaviour
{
    public TextMeshProUGUI text;
    public CurrencyData boneData;


    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (text != null && boneData != null)
        {
            text.text = boneData.silverAmount.ToString();
        }
        else
        {
            Debug.Log("Not \"text\" or \"boneData\"");

        }
    }
}