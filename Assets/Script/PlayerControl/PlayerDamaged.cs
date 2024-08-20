using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerDamaged : MonoBehaviour
{
    private const string bulletTag = "BULLET";
    private float initHp = 100.0f;
    public float currHP;
    void Start()
    {
        currHP = initHp;
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == bulletTag)
        {
            Destroy(coll.gameObject);

            currHP -= 5.0f;
            Debug.Log("Player HP = " + currHP.ToString());

            if(currHP <= 0.0f)
            {
                PlayerDie();
            }
        }
    }
}
