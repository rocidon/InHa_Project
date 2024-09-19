using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWeapon : MonoBehaviour
{
    [SerializeField]
    public GameObject Effect;
    BoxCollider coll;
        
    private void Awake()
    {
        coll = GetComponent<BoxCollider>();
        ControlTrigger(false);
    }
    public void ControlTrigger(bool val)
    {
        coll.isTrigger = val;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("NormalMonster Hit Player");
            Instantiate(Effect, other.transform.position, Quaternion.identity);
            ControlTrigger(false);
        }
    }
}
