using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Boss1에 대한 행동 패턴들
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
    public NormalAttack() { }

    public override NodeState Evaluate()
    {

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
    public Dying() { }
    public override NodeState Evaluate()
    {
        
        return state = NodeState.Success;
    }
}

public class InCloseRange : Node
{

    public InCloseRange() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}

public class NormalAttackCount : Node
{
    public NormalAttackCount() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}
public class JumpAttackPattern : Node
{
    public JumpAttackPattern() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}
public class AnyAttackCount : Node
{
    public AnyAttackCount() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}
public class InLongRange : Node
{
    public InLongRange() { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}
public class ProjectileAttackPattern : Node
{
    public ProjectileAttackPattern() { }
    public override NodeState Evaluate()
    {
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
        throw new NotImplementedException();
    }
}