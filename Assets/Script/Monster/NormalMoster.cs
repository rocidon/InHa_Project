using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//https://danpung2.tistory.com/58
public class NormalMoster : Monster
{
    RaycastHit hit;
    enum State
    {
        Idle,
        Move,
        Attack,
        Death
    }
    State _currentState;
    public float speed;
    //FSM _fsm;
    void Start()
    {
        _Health = 200.0f;
        _Atk = 10.0f;
        _Def = 1.0f;
        _currentState = State.Idle;
        _fsm = new FSM(new IdleState(this));
        speed = speed >= 1.0f ? speed : 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //변경 필요
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
        }
    }

    public void RayHit()
    {
        Vector3 ChkPos = transform.forward + transform.position;
        Debug.DrawRay(ChkPos, Vector3.down * 0.5f, Color.green, 0.01f);
        if(!Physics.Raycast(ChkPos, Vector3.down, out hit, 0.5f))
        {
            Turn();
        }
    }

    void Turn()
    {
        Vector3 BackVec = transform.forward * -1;
        if(BackVec != Vector3.zero)
        {
            transform.forward = BackVec;
        }
    }
    
}

//각 행동 State에 대해 정의해야함
public class IdleState : BaseState
{
    private NormalMoster _normalMob;
    public IdleState(NormalMoster monster) : base(monster) {
        _normalMob = monster;
    }

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
    private NormalMoster _normalMob;
    public MoveState(NormalMoster monster) : base(monster) {
        _normalMob = monster;
    }
    
    public override void onStateEnter()
    {
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        _normalMob.transform.Translate(Vector3.forward * _normalMob.speed * Time.deltaTime);
        _normalMob.RayHit();
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}
public class AttackState : BaseState
{
    private NormalMoster _normalMob;
    public AttackState(NormalMoster monster) : base(monster)
    {
        _normalMob = monster;
    }

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