using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData; // ���� ������ ������
    [SerializeField] private Button addButton; // �߰� ��ư
    [SerializeField] private Inventory inventory; // �κ��丮
    [SerializeField] private TextMeshProUGUI weaponNameText; // ���� �̸� �ؽ�Ʈ (TextMeshProUGUI)
    [SerializeField] private Image weaponImage; // ���� �̹��� UI ���

    private void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �ڵ鷯 �߰�
        if (addButton != null)
        {
            addButton.onClick.AddListener(OnAddButtonClicked);
        }

        // UI ������Ʈ
        UpdateUI();
    }

    // ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    private void OnAddButtonClicked()
    {
        inventory?.AddItem(weaponData);
    }

    // UI ������Ʈ
    private void UpdateUI()
    {
        if (weaponNameText != null && weaponData != null)
        {
            weaponNameText.text = weaponData.itemName;
        }

        if (weaponImage != null && weaponData != null)
        {
            weaponImage.sprite = weaponData.itemImage;
        }
    }
}
