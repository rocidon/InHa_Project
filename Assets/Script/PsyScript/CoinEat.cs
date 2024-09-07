using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEat : MonoBehaviour
{

    public CurrencyData currencyData;

    // ���� ��ȭ�� 
    public int silverCoin = 0;
    public int goldCoin = 0; 

    // ���� �Ա�
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerMove>().coin++;
            currencyData.curSilverAmount += silverCoin;
            currencyData.curGoldAmount += goldCoin;
            

            Destroy(this.gameObject);
        }
    }
}
