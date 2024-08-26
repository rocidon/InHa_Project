using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    float Damage;
    float _AttackTime;
    public bool IsAtk;
    private void Start()
    {
        IsAtk = false;
    }
    public void SetDamage(float damage)
    {
        Damage = damage;
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (IsAtk)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("HIt");
                Debug.Log(_AttackTime);
                //PlayerClass player_value_name = other.gameObject.GetComponent<PlayerClass>();
                //Damaged player at this Damage
                IsAtk = false;
            }
        }
    }
}
