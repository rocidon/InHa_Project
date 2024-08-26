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

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
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

        attackPowerText.text = "Attack    " + curAttack;
        durabilityText.text = "Durability    " + curDurability;
    }
}

