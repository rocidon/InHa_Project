using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxEat : MonoBehaviour
{
        // ������ �Ա�
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                //collision.gameObject.GetComponent<PlayerMove>().itembox++;
                Destroy(this.gameObject);
            }
        }
    

}
