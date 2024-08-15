using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected float _Health;
    protected float _Atk;
    protected float _Def;
    protected FSM _fsm;
    
    protected bool IsDeath()
    {
        if(_Health <= 0.0f)
        {
            return true;
        }
        return false;
    }
}

