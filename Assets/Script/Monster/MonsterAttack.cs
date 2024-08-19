using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    float Damage;
    float _Timer;
    float _AttackTime;
    BoxCollider AtkRange;
    public bool IsAtk;
    private void Start()
    {
        IsAtk = false;
    }

    private void Update()
    {
    }
    public void SetDamage(float damage)
    {
        Damage = damage;
    }
    public void SetAttackTime(float time)
    {
        _AttackTime = time;
    }
    public void DelColl()
    {
        Destroy(this);
    }
    public void SetCollsionVolume(Vector3 StartPostion, Vector3 Size)
    {
        AtkRange.center = StartPostion;
        AtkRange.size = Size;
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
