using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Button slotButton;
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private Image weaponImage;
    
    public int silverPrice;
    public int goldPrice;
    [SerializeField] private CurrencyData currencyData;

    [SerializeField] private TextMeshProUGUI silverPriceText;
    [SerializeField] private TextMeshProUGUI goldPriceText;

    private Inventory canvasInventory;
    private InventorySlot[] slots;
    private void Start()
    {
        canvasInventory = FindObjectOfType<Inventory>();

        // ���� ������ Inventory�� ã��.
        if (canvasInventory == null)
        {
            Debug.Log("not found Inventory");
        }

        // ��ư�� ������ �ش� �Լ� ����
        if (slotButton != null)
        {
            slotButton.onClick.AddListener(OnClickButton);
        }

        // ������ Item ���� ǥ��
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

        // ���� ��ȭ�� �������� ������ �����ϴ���
        bool silverCheck = currencyData.silverAmount >= silverPrice;
        bool goldCheck = currencyData.goldAmount >= goldPrice;

        if ((silverCheck && goldCheck)&& canvasInventory.items.Count == 0)
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
