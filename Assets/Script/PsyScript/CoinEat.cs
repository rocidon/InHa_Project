using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEat : MonoBehaviour
{
    public CurrencyData currencyData;
    // ÄÚÀÎ ¸Ô±â
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerMove>().coin++;
            currencyData.curGoldAmount += 100;
            Destroy(this.gameObject);
        }
    }
}
