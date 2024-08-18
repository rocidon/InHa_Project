using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData; // 상점 아이템 데이터
    [SerializeField] private Button addButton; // 추가 버튼
    [SerializeField] private Inventory inventory; // 인벤토리
    [SerializeField] private TextMeshProUGUI weaponNameText; // 무기 이름 텍스트 (TextMeshProUGUI)
    [SerializeField] private Image weaponImage; // 무기 이미지 UI 요소

    private void Start()
    {
        // 버튼 클릭 이벤트에 핸들러 추가
        if (addButton != null)
        {
            addButton.onClick.AddListener(OnAddButtonClicked);
        }

        // UI 업데이트
        UpdateUI();
    }

    // 버튼 클릭 이벤트 핸들러
    private void OnAddButtonClicked()
    {
        inventory?.AddItem(weaponData);
    }

    // UI 업데이트
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
