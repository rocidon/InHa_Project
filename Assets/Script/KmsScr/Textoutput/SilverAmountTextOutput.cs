using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; 


public class SilverAmountTextOutput : MonoBehaviour
{
    public TextMeshProUGUI text;
    public CurrencyData silverData;


    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (text != null && silverData != null)
        {
            text.text = silverData.silverAmount.ToString();
        }
        else
        {
            Debug.Log("Not \"text\" or \"boneData\"");

        }
    }
}