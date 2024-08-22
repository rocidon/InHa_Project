using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Boss1에 대한 행동 패턴들
//https://leekangw.github.io/posts/91/
//Evalute : realize Behavior Space

public class TestNode : Node
{
    public TestNode()
    {
        //Debug.Log("This is TestNode");
    }
    public override NodeState Evaluate()
    {
        Debug.Log("This is TestNode Running");
        return state = NodeState.Running;
    }
}
public class ChkHeath : Node
{
    Monster monster;
    public ChkHeath()
    {

    }
    public ChkHeath(Monster monster)
    {
        this.monster = monster;
    }
    public ChkHeath(Transform transform)
    {
        monster = transform.GetComponent<Monster>();
    }
    public override NodeState Evaluate()
    {
        //Debug.Log(monster._Health);
        //Debug.Log(monster.GetName());
        //Debug.Log(monster._Health);
        if (monster._Health <= 50.0f)
        {
            if (monster._Health > 0f)
            {
                Debug.Log("HP <= 50 && > 0");
                return NodeState.Success;
            }
        }
        return NodeState.Failure;
    }
}

public class ChkTimer : Node
{
    float ChkingTime;
    public ChkTimer(float timer)
    {
        ChkingTime = timer;
    }
    public override NodeState Evaluate()
    {
        //Debug.Log("Current Time : " + NodeTimer);
        if (NodeTimer >= ChkingTime)
        {
            NodeTimer = 0;
            Debug.Log("Over Time! go next Node");
            return NodeState.Success;
        }
        return NodeState.Failure;
    }
}
public class NormalAttack : Node
{
    Animator Anim;
    public NormalAttack() {
        
    }
    public NormalAttack(Transform transform)
    {
        Anim = transform.GetComponent<Animator>();
    }
    public NormalAttack(Monster monster) {
        Anim = monster.animator;
    }

    public override NodeState Evaluate()
    {
        //Write Animator Parmeter value setting
        Anim.SetBool("IsNormalAttack", true);
        return state = NodeState.Running;
    }
}
public class InstantKilAttack1 : Node
{
    public InstantKilAttack1() { }

    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}

public class InstantKilAttack2 : Node
{
    public InstantKilAttack2() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}

public class Dying : Node
{
    Animator Anim;
    Transform t;
    public Dying() { }
    public Dying(Transform transform) {
        Anim = transform.GetComponent <Animator>();
        t = transform;
    }
    public override NodeState Evaluate()
    {
        if(NodeTimer > 3.0f) {
            NodeTimer = 0;
            //SetAnimator Dying value
            //Play Dying Event
            return state = NodeState.Success;
        }
        return state = NodeState.Running;
    }
}

public class InCloseRange : Node
{
    //Target and This parmeter 
    float Range;
    Transform Target;
    Transform Center;
    public InCloseRange() {
        Range = 10.0f;
        Target = null;
    }
    public InCloseRange(Transform Taget, Transform SELF,float range)
    {
        Range = range;
        this.Target = Taget;
        Center = SELF;
    }
    public override NodeState Evaluate()
    {
        Vector3 v= Target.position - Center.position;
        float distance = Vector3.Magnitude(v);
        if(distance <= Range)
        {
            return state = NodeState.Success;
        }
        return state = NodeState.Failure;
    }
}

public class NormalAttackCount : Node
{
    BossMonster1 boss;
    int ChkCount;
    public NormalAttackCount() {
        ChkCount = 0;
    }
    public NormalAttackCount(BossMonster1 boss, int ChkCount) {
        this.boss = boss;
        this.ChkCount = ChkCount;
    }
    public override NodeState Evaluate()
    {
        if(boss.NormalAttackCount > ChkCount)
        {
            return state = NodeState.Success;
        }
        return state = NodeState.Failure;
    }
}
public class JumpAttackPattern : Node
{
    public JumpAttackPattern() {
    //Get Monster Class
    }
    public override NodeState Evaluate()
    {
        //Realize JumpAttackPattern
        throw new NotImplementedException();
    }
}
public class AnyAttackCount : Node
{
    public AnyAttackCount() { }
    public override NodeState Evaluate()
    {
        //AnyAttackCount = Normal Attack Count + jump + projectile
        throw new NotImplementedException();
    }
}
public class InLongRange : Node
{
    float ChkDistance;
    public InLongRange() { }
    public override NodeState Evaluate()
    {
        //if(Range > ChkDistance) true;
        throw new NotImplementedException();
    }
}
public class ProjectileAttackPattern : Node
{
    public ProjectileAttackPattern() { }
    public override NodeState Evaluate()
    {
        return state = NodeState.Running;
        throw new NotImplementedException();
    }
}
public class SpecialAttackPattern1 : Node
{
    public SpecialAttackPattern1() { }
    public override NodeState Evaluate()
    {

        throw new NotImplementedException();
    }
}
public class SpecialAttackCount : Node
{
    public SpecialAttackCount() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}
public class SpecialAttackPattern2 : Node
{
    public SpecialAttackPattern2() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}
public class ChasePlayer : Node
{
    public ChasePlayer() { }
    public override NodeState Evaluate()
    {
        //use lerp?
        throw new NotImplementedException();
    }
}