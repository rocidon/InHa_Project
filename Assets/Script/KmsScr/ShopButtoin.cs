using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Inventory canvasInventory;

    [SerializeField] private Button slotButton;

    [SerializeField] private WeaponData weaponData;
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private Image weaponImage;

    [SerializeField] private CurrencyData currencyData; 


    public int silverPrice;
    public int goldPrice;

    [SerializeField] private TextMeshProUGUI silverPriceText;
    [SerializeField] private TextMeshProUGUI goldPriceText;


    private void Start()
    {

        if (slotButton != null)
        {
            slotButton.onClick.AddListener(OnClickButton);
        }

        silverPriceText.text = silverPrice.ToString();
        goldPriceText.text = goldPrice.ToString();



        UpdateUI();
    }

    private void OnClickButton()
    {

        if (currencyData == null || weaponData == null || canvasInventory == null)
        {
            Debug.Log("Data x");
            return;
        }



        bool silverCheak = currencyData.silverAmount >= silverPrice;
        bool goldCheak = currencyData.goldAmount >= goldPrice;

        if (silverCheak && goldCheak)
        {
            currencyData.silverAmount -= silverPrice;
            currencyData.goldAmount -= goldPrice;

            canvasInventory.AddItem(weaponData);
            Debug.Log("success");
        }
        else
        {
            Debug.Log("fail");
        }
    }


    private void UpdateUI()
    {
        if (weaponName != null && weaponData != null)
        {
            weaponName.text = weaponData.itemName;
        }

        if (weaponImage != null && weaponData != null)
        {
            weaponImage.sprite = weaponData.itemImage;
        }
    }

}
