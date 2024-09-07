using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //if(hit.collider != null && hit.collider.gameObject.tag =="Sphere")
           
                    Debug.Log("ÅÍÄ¡µÈ °´Ã¼: " + hit.collider.gameObject.name);

                    Toggle();
                
            }
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