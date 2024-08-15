using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    private void Start()
    {
            panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Toggle(); 
        }

    }

    private void Toggle()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
            Debug.Log("Success InvenToggle.scr");

        }
        else
        {
            Debug.Log("Error InvenToggle.scr");
        }
    }
}


/* //void Update()... Esc key inven x

         if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel != null && panel.activeSelf)
            {
                panel.SetActive(false);
                Debug.Log("Success 'Esc' InvenToggle.scr");
            }
        }
 
 
 */