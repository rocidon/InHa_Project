using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMonster : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<NormalMonster>().Turn();
        }
    }
}
