using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float _MaxHealth;
    public float _Health;
    public float _Atk;
    public float _Def;
    public FSM _fsm;
    public float speed;
    public Animator animator;
    public bool _IsAction;
    protected bool IsDying;
    protected bool Isaction;
    private enum MonsterState
    {
        Idle,
        Move,
        Attack,
        Death
    }
    //후에 기능별로 virtual 타입의 함수로 기능들을 분리해둘것
    //private MonsterState _state;
    public string GetName()
    {
        string thisname = gameObject.name;
        return thisname;
    }
    public bool IsDeath()
    {
        if(_Health <= 0.0f)
        {
            return true;
        }
        return false;
    }

    public float GetMaxHP()
    {
        return _MaxHealth;
    }
    public virtual void Movement()
    {
        Debug.Log("I'm parnet Class Movement!");
    }
    public virtual void Idle()
    {
        Debug.Log("I'm parent Class Idle");
    }
    public virtual void AttackFail()
    {
        Debug.Log("Fail Attack");
    }
    public virtual void Attack()
    {
        Debug.Log("I'm Parnet Class Attck");
    }
    public virtual void ChangeAnimation(bool value)
    {
        Debug.Log("I'm Parent Class ChangeAnimation");
    }
    public virtual void AttackEnd()
    {
        Debug.Log("I'm Parent Class AttackEnd");
    }
    public virtual void TakeDamage(float damage)
    {
        //_Health -= damage;
        //Debug.Log(_Health);
        //StartCoroutine(OnDamage());
    }
    public virtual void Dying()
    {
        Destroy(gameObject);
    }

    public virtual IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.2f);
    }
}

