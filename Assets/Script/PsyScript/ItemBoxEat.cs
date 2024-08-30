using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ItemBoxEat : MonoBehaviour
{
    
        // æ∆¿Ã≈€ ∏‘±‚
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<PlayerMovePsy>().itembox++;
            Destroy(this.gameObject);
        }
        
    }
    

}
