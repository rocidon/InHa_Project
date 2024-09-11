using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxEat : MonoBehaviour
{
        // æ∆¿Ã≈€ ∏‘±‚
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "RogueHooded")
            {
                //collision.gameObject.GetComponent<PlayerMove>().itembox++;
                Destroy(this.gameObject);
            }
        }
    

}
