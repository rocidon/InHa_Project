using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
//https://danpung2.tistory.com/58
public class NormalMonster : Monster
{
    RaycastHit hit;
    enum State
    {
        Idle,
        Move,
        Attack,
        See,
        Death
    }
    State _currentState;
    public float speed;
    float oSpeed;
    public float AtkRange;
    Field_of_View fov;
    //FSM _fsm;
    void Start()
    {
        fov = GetComponent<Field_of_View>();
        //Debug.Log(fov.a);
        _Health = 200.0f;
        _Atk = 10.0f;
        _Def = 1.0f;
        _currentState = State.Idle;
        _fsm = new FSM(new IdleState(this));
        speed = speed >= 1.0f ? speed : 5.0f;
        oSpeed = speed;
        AtkRange = AtkRange >= 1.0f ? AtkRange : 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fov.AtkPlayer);
        Debug.Log(_currentState); 
        switch (_currentState)
        {
            
            case State.Idle:
                if (fov.FindPlayer == false)
                {
                    ChangeState(State.Move);                   
                }
                else
                {
                    ChangeState(State.See);
                }
                break;
            case State.Move:
                speed = oSpeed;
                if (fov.FindPlayer)
                {
                    ChangeState(State.See);
                }
                else
                {
                    ChangeState(State.Idle);
                }
                break;
            case State.Attack:

                if (fov.AtkPlayer== false)
                {
                    ChangeState(State.See);
                }
                break;
            case State.See:
                speed = 0.5f;
                if (fov.FindPlayer)
                {
                    if (fov.AtkPlayer)
                    {
                        ChangeState(State.Attack);
                    }               
                }
                else
                {
                    ChangeState (State.Idle);
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
            case State.See:
                _fsm.ChangeState(new SeeState(this));
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
    bool DetectedPLayer()
    {
        Vector3 CurrentPos = transform.position;

        return true;
    }
    
}

//각 행동 State에 대해 정의해야함
public class IdleState : BaseState
{
    private NormalMonster _normalMob;
    public IdleState(NormalMonster monster) : base(monster) {
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
    private NormalMonster _normalMob;
    public MoveState(NormalMonster monster) : base(monster) {
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
    private NormalMonster _normalMob;
    public AttackState(NormalMonster monster) : base(monster)
    {
        _normalMob = monster;
    }

    public override void onStateEnter()
    {
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        //Debug.Log("Attack!");
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}

public class SeeState : BaseState
{
    private NormalMonster _normalMob;
    public SeeState(NormalMonster monster) : base(monster)
    {
        _normalMob = monster;
    }
    public override void onStateEnter()
    {
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        _normalMob.transform.Translate(Vector3.forward * _normalMob.speed * Time.deltaTime);
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}