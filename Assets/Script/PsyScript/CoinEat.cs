using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEat : MonoBehaviour
{
    
    // ���� �Ա�
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerMove>().coin++;
            Destroy(this.gameObject);
        }
    }
}
