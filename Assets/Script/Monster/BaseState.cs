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
    //상태에 처음 진입했을 때 한 번만 호출되는 메서드
    public abstract void onStateEnter();
    //매 프레임마다 호출되어야 하는 메서드
    public abstract void onStateUpdate();
    //상태가 변경되면 호출되는 메서드
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
