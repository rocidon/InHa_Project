using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ItemBoxEat : MonoBehaviour
{
    
        // ������ �Ա�
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            if (collision.gameObject.tag == "Player")
            {
                //collision.gameObject.GetComponent<PlayerMove>().itembox++;
                Destroy(this.gameObject);
            }
=======
            
            collision.gameObject.GetComponent<PlayerMovePsy>().itembox++;
            Destroy(this.gameObject);
>>>>>>> ParkSinYoung
        }
        
    }
    

}
