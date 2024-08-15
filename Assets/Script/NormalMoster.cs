using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMoster : Monster
{
    enum State
    {
        Idle,
        Move,
        Attack,
        Death
    }

    State _currentState;
    //FSM _fsm;
    void Start()
    {
        _Health = 200.0f;
        _Atk = 10.0f;
        _Def = 1.0f;
        _currentState = State.Idle;
        _fsm = new FSM(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case State.Idle:
                if (true)//see player
                {
                    if(_Health > 0)//canatkplayer
                    {
                        ChangeState(State.Attack);
                    }
                    else
                    {
                        ChangeState(State.Move);
                    }
                }
                break;
            case State.Move:
                if(_Health> 0)//see player
                {
                    if(_Health >0)//atk player
                    {
                        ChangeState(State.Attack);
                    }
                }
                else
                {
                    ChangeState(State.Idle);
                }
                break;
            case State.Attack:
                if(_Health > 0)//see player
                {
                    if(_Health>0)//!atk player
                    {
                        ChangeState(State.Move);
                    }
                }
                else
                {
                    ChangeState(State.Idle);
                }
                break;
            case State.Death:
                if (IsDeath())
                {
                    ChangeState(State.Death);
                }
                break;

        }
        _fsm.UpdateState();
    }

    void ChangeState(State nextstate)
    {
        _currentState = nextstate;
        switch(_currentState)
        {
            case State.Idle:
                _fsm.ChangeState(new IdleState(this));
                break;
            case State.Move:
                _fsm.ChangeState(new MoveState(this));
                break;
            case State.Attack:
                _fsm.ChangeState(new AttackState(this));
                break;
            case State.Death:
                Destroy(this);
                break;
        }
    }
}

//각 행동 State에 대해 정의하는 것
public class IdleState : BaseState
{
    public IdleState(Monster monster) : base(monster) { }

    public override void onStateEnter()
    {
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}
public class MoveState : BaseState
{
    public MoveState(Monster monster) : base(monster) { }

    public override void onStateEnter()
    {
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}
public class AttackState : BaseState
{
    public AttackState(Monster monster) : base(monster) { }

    public override void onStateEnter()
    {
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}