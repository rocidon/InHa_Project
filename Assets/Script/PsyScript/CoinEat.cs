using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEat : MonoBehaviour
{
    
    // ÄÚÀÎ ¸Ô±â
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            //collision.gameObject.GetComponent<PlayerMove>().coin++;
=======
            collision.gameObject.GetComponent<PlayerMovePsy>().coin++;
>>>>>>> ParkSinYoung
            Destroy(this.gameObject);
        }
    }
}
