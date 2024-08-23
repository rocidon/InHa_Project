using UnityEngine;
using TMPro;

public enum CurrencyType
{
    GoldAmount,
    SilverAmount,
    CurGoldAmount,
    CurSilverAmount
}

public class CurrencyAmountTextOutput : MonoBehaviour
{
    public TextMeshProUGUI text;
    public CurrencyData currencyData;

    public CurrencyType Type; 

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (text != null && currencyData != null)
        {
            switch (Type)
            {
                case CurrencyType.GoldAmount:
                    text.text = currencyData.goldAmount.ToString();
                    break;

                case CurrencyType.SilverAmount:
                    text.text = currencyData.silverAmount.ToString();
                    break;

                case CurrencyType.CurGoldAmount:
                    text.text = currencyData.curGoldAmount.ToString();
                    break;

                case CurrencyType.CurSilverAmount:
                    text.text = currencyData.curSilverAmount.ToString();
                    break;

                default:
                    Debug.Log("Not CurrencyType");
                    break;
            }
        }
        else
        {
            Debug.Log("Not Data");
        }
    }
}
