using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public abstract class BaseState
{
    private Monster _monster;

    protected BaseState(Monster monster)
    {
        _monster = monster;
    }
    //���¿� ó�� �������� �� �� ���� ȣ��Ǵ� �޼���
    public abstract void onStateEnter();
    //�� �����Ӹ��� ȣ��Ǿ�� �ϴ� �޼���
    public abstract void onStateUpdate();
    //���°� ����Ǹ� ȣ��Ǵ� �޼���
    public abstract void onStateExit();
}

//public class IdleState : BaseState
//{
//    public IdleState(Monster monster) : base(monster) { }

//    public override void onStateEnter()
//    {
//        //throw new System.NotImplementedException();
//    }
//    public override void onStateUpdate()
//    {
//        //throw new System.NotImplementedException();
//    }

//    public override void onStateExit()
//    {
//        //throw new System.NotImplementedException();
//    }
//}
//public class MoveState : BaseState
//{
//    public MoveState(Monster monster) : base(monster) { }

//    public override void onStateEnter()
//    {
//        //throw new System.NotImplementedException();
//    }
//    public override void onStateUpdate()
//    {
//        //throw new System.NotImplementedException();
//    }

//    public override void onStateExit()
//    {
//        //throw new System.NotImplementedException();
//    }
//}
//public class AttackState : BaseState
//{
//    public AttackState(Monster monster) : base(monster) { }

//    public override void onStateEnter()
//    {
//        //throw new System.NotImplementedException();
//    }
//    public override void onStateUpdate()
//    {
//        //throw new System.NotImplementedException();
//    }

//    public override void onStateExit()
//    {
//        //throw new System.NotImplementedException();
//    }
//}
