using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected float _Health;
    protected float _Atk;
    protected float _Def;
    protected FSM _fsm;
    
    private enum MonsterState
    {
        Idle,
        Move,
        Attack,
        Death
    }

    private MonsterState _state;

    private void Start()
    {
        _state = MonsterState.Idle;
    }
    private void Update()
    {
        switch (_state) { 
            case MonsterState.Idle:
                break;
            case MonsterState.Move:
                break;
            case MonsterState.Attack:
                break;
            case MonsterState.Death:
                break;
        }
    }
    protected bool IsDeath()
    {
        if(_Health <= 0.0f)
        {
            return true;
        }
        return false;
    }
}

