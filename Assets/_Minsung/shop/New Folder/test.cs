using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI silverPriceText;
    [SerializeField] private TextMeshProUGUI goldPriceText; 

    [SerializeField] private Image silverIconImage;
    [SerializeField] private Image goldIconImage; 

    [SerializeField] private PriceData priceData;
    [SerializeField] private CurrencyData currencyData;

    // Start is called before the first frame update
    void Start()
    {
        if (priceData != null)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        silverPriceText.text = priceData.silverPrice.ToString();
        goldPriceText.text = priceData.goldPrice.ToString();
        silverIconImage.sprite = priceData.silverIcon;
        goldIconImage.sprite = priceData.goldIcon;

        bool isSilverHigher = currencyData.silverAmount > priceData.silverPrice;
        bool isGoldHigher = currencyData.goldAmount > priceData.goldPrice;

        if (isSilverHigher && isGoldHigher)
        {
            currencyData.silverAmount -= priceData.silverPrice;
            currencyData.goldAmount -= priceData.goldPrice;
            Debug.Log("Yes");
        }
        else
        {
            Debug.Log("No");
        }

    }


}
