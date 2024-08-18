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
    public enum State
    {
        Idle,
        Move,
        See,
        Attack,
        Hited,
        Death
    }
    public State _currentState;
    public float AtkRange;
    float oSpeed;
    float _Timer;
    bool CantMove;
    Field_of_View fov;
    MonsterAttack Atk;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Atk = GetComponentInChildren<MonsterAttack>();
        _Timer = 0f;
        fov = GetComponent<Field_of_View>();
        _Health = 200.0f;
        _Atk = 10.0f;
        _Def = 1.0f;
        _currentState = State.Idle;
        _fsm = new FSM(new IdleState(this));
        speed = speed >= 1.0f ? speed : 5.0f;
        oSpeed = speed;
        AtkRange = AtkRange >= 1.0f ? AtkRange : 3.0f;
        CantMove = false;
        Atk.SetDamage(_Atk);
        Atk.SetAttackTime(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeAnimation(true);
        //Debug.Log(animator.GetParameter((int)_currentState).name);
        //Debug.Log(fov.AtkPlayer);
        //Debug.Log(_currentState); 
        switch (_currentState)
        {            
            case State.Idle:
                if (fov.FindPlayer == false)
                {
                    if(_Timer > 1.0f)
                    {
                        ChangeState(State.Move);
                        _Timer = 1.0f;
                    }
                    _Timer += Time.deltaTime;
                }
                else
                {
                    ChangeState(State.See);
                    _Timer = 0f;
                }
                break;
            case State.Move:
                speed = 2.0f;
                if (fov.FindPlayer)
                {
                    ChangeState(State.See);
                    _Timer = 0f;
                }
                else
                {
                    if(_Timer > 3.0f)
                    {
                        ChangeState(State.Idle);
                        _Timer = 0;
                    }
                    _Timer += Time.deltaTime;
                }
                break;
            case State.Attack:

                if (fov.AtkPlayer== false)
                {
                    ChangeState(State.See);
                }
                break;
            case State.See:                
                speed = oSpeed;
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
            case State.Hited:
                if (CantMove)
                {
                    if (IsDeath())
                    {
                        ChangeState(State.Death);
                    }
                    else
                    {
                        ChangeState(State.Idle);
                        CantMove = false;
                    }
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
        if (_currentState == nextstate) return;

        ChangeAnimation(false);
        _currentState = nextstate;
        ChangeAnimation(true);

        switch (_currentState)
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
            case State.Hited:
                _fsm.ChangeState(new HittedState(this));
                break;
        }
    }
    void RayHit()
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
    public override void Movement() { 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RayHit();
        //base.Movement();
    }

    public override void ChangeAnimation(bool value)
    {
        int index = (int)_currentState;
        string idxName = animator.GetParameter(index).name;
        //bool oval = animator.GetBool(idxName);
        //Debug.Log("Current State : " + index);
        if(_currentState == State.Hited)
        {
            animator.SetTrigger(idxName);
        }
        else
        {
            animator.SetBool(idxName, value);
        }

    }

    public override void Attack()
    {
        Atk.IsAtk = true;
    }
    public override void TakeDamage(float damage)
    {
        _Health -= damage;
        Debug.Log(_Health);
        StartCoroutine(OnDamage());
    }

    public override IEnumerator OnDamage()
    {
        Debug.Log("!!");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -4, ForceMode.Impulse);
        //rb.MovePosition(transform.forward * -2);
        ChangeState(State.Hited);
        animator.SetBool(0, true);
        yield return new WaitForSeconds(2.0f);
        
        CantMove = true;
    }
}

//�� �ൿ State�� ���� �����ؾ���
public class IdleState : BaseState
{
    private Monster _normalMob;
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
    //private NormalMonster _normalMob;
    private Monster _normalMob;
    public MoveState(Monster monster) : base(monster) {
        _normalMob = monster;
    }
    
    public override void onStateEnter()
    {
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        _normalMob.Movement();
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {

        //throw new System.NotImplementedException();
    }
}
public class AttackState : BaseState
{
    private Monster _normalMob;
    public AttackState(Monster monster) : base(monster)
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
        _normalMob.Attack();
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}

public class SeeState : BaseState
{
    private Monster _normalMob;
    public SeeState(Monster monster) : base(monster)
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

public class DeathState : BaseState
{
    private NormalMonster _normalMob;
    public DeathState(NormalMonster monster) : base(monster)
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

public class HittedState : BaseState
{
    private NormalMonster _normalMob;
    public HittedState(NormalMonster monster) : base(monster)
    {
        _normalMob = monster;
    }
    public override void onStateEnter()
    {
        _normalMob.OnDamage();
        //throw new System.NotImplementedException();
    }
    public override void onStateUpdate()
    {
        //_normalMob.transform.Translate(Vector3.forward * _normalMob.speed * Time.deltaTime);
        //throw new System.NotImplementedException();
    }

    public override void onStateExit()
    {
        //throw new System.NotImplementedException();
    }
}