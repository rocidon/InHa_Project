using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<WeaponData> items;

    [SerializeField] private GameObject panel;

    [SerializeField]private Transform slotParent;
    [SerializeField] private InventorySlot[] slots;

    [SerializeField] private TextMeshProUGUI attackPowerText;
    [SerializeField] private TextMeshProUGUI durabilityText;

#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<InventorySlot>();
    }
#endif

    void Awake()
    {
        FreshSlot();
    }

    //아이템이 들어오거나하면 Slot의 내용을 정리하여 화면에 보여주는 기능
    public void FreshSlot()
    {
        int i = 0;
        //slot에 item이 들어가면 Slot.cs에 선언된 item의 set 안의 내용이 실행되어 해당 슬롯에 이미지를 표시
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        // item이 없다면 null 처리
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }

        UpdateAttackPowerText();

    }
    
    public void AddItem(WeaponData _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }

    void Start()
    {
        //인벤토리(상태창)의 패널을 처음에 false
        panel.SetActive(false);
    }
    void Update()
    {
        FreshSlot();
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed the \'I\'");
            Toggle();
        }

    }

    // 인벤토리(상태창) Toggle
    private void Toggle()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
        else
        {
            Debug.Log("Error InvenToggle.scr");
        }
    }

    // 인벤토리(상태창) 공격력, 내구도 업데이트
    private void UpdateAttackPowerText()
    {
        float curAttack = 0f;
        float curDurability = 0f;


        if (attackPowerText != null && items.Count > 0)
        {
            float itemrAttack = (float)items[0].attackPower;
            float itemDurability = (float)items[0].durability;

            curAttack += itemrAttack;
            curDurability += itemDurability;
        }
        else
        {
            // ----
        }

        attackPowerText.text =  "공격력    " + curAttack;
        durabilityText.text =   "내구도    " + curDurability;
    }
}

