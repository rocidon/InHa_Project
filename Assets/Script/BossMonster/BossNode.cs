using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//Boss1에 대한 행동 패턴들
//https://leekangw.github.io/posts/91/
//Evalute : realize Behavior Space

public class TestNode : Node
{
    BossMonster1 boss;
    float TestTimer;
    public TestNode()
    {
        Debug.Log("incloseRange Create!!");
        TestTimer = 0.0f;
    }
    public TestNode(BossMonster1 boss)
    {
        this.boss = boss;
        //Debug.Log("incloseRange Create!!");
    }
    public override NodeState Evaluate()
    {
        //Debug.Log("Timer : " + TestTimer);
        TestTimer += Time.deltaTime;
        if (TestTimer > 3.0f)
        {
            Debug.Log("Time OUT! Current : " + TestTimer);
            TestTimer = 0.0f;
            return state = NodeState.Failure;
        }
        return state = NodeState.Running;
    }
}
public class TestNode2 : Node
{
    public TestNode2()
    {
        Debug.Log("This is Test2");
    }
    public override NodeState Evaluate()
    {

        Debug.Log("This is Tets2 Evaluate");

        return state = NodeState.Running;
    }
}
public class IDLE : Node
{
    BossMonster1 boss;
    public IDLE()
    {}
    public IDLE(BossMonster1 boss)
    {
        this.boss = boss;
    }
    public override NodeState Evaluate()
    {
        Debug.Log("Idle State");
        //animation set idle state
        return state = NodeState.Running;
        throw new NotImplementedException();
    }
}
public class ChkHeath : Node
{
    BossMonster1 boss;
    float MAXHP;
    public ChkHeath()
    {

    }
    public ChkHeath(BossMonster1 boss)
    {
        this.boss = boss;
    }
    public override NodeState Evaluate()
    {
        MAXHP = boss.GetMaxHP();
        float LimitHP = MAXHP * 0.1f;
        
        if (boss._Health <= LimitHP)
        {
            if (boss._Health > 0f)
            {
                Debug.Log("Limit HP : " + LimitHP);
                return NodeState.Success;
            }
        }
        return NodeState.Failure;
    }
}

public class ChkTimer : Node
{
    float NodeTimer;
    float ChkTime;
    public ChkTimer(float timer)
    {
        ChkTime = timer;
    }
    public override NodeState Evaluate()
    {
        NodeTimer += Time.deltaTime;
        //Debug.Log("Current Time : " + NodeTimer);
        if (NodeTimer >= ChkTime)
        {   
            NodeTimer = 0.0f;
            Debug.Log("Over "+ChkTime +" Move Next Node");
            return NodeState.Success;
        }
        return NodeState.Failure;
    }
}
public class NormalAttack : Node
{
    BossMonster1 boss;
    public NormalAttack() {
        
    }
    public NormalAttack(BossMonster1 boss) {
        this.boss = boss;
    }

    public override NodeState Evaluate()
    {
        //Write Animator Parmeter value setting
        //boss.NormalAttack()
        return state = NodeState.Running;
    }
}

public class IsPlayInstantKill : Node
{
    BossMonster1 boss;
    bool IsPlay;
    public IsPlayInstantKill() { }
    public IsPlayInstantKill(BossMonster1 boss) {
        this.boss = boss;
        IsPlay = this.boss.GetInstantKillCount();
    }
    public override NodeState Evaluate()
    {
        if (boss.GetInstantKillCount())
        {
            Debug.Log("Played All Pattern");
            return state = NodeState.Failure;
        }
        Debug.Log("Pattern Start");
        return state = NodeState.Success;
    }
}
public class InstantKilAttack1 : Node
{
    MonoBehaviour mono;
    //Test Use coRoutine about Walking 10sec 
    GameObject FootHold;
    BossMonster1 Boss;
    bool ChkPlayed;
    int count = 0;
    float InnerTimer;
    public InstantKilAttack1() { }
    public InstantKilAttack1(BossMonster1 boss) {
        Boss = boss;
        ChkPlayed = true;
        state = NodeState.Failure;
        InnerTimer = 0.0f;
    }

    public override NodeState Evaluate()
    {
        if (Boss.IsPlayKillPattern1())
        {
            Debug.Log("Played Kill Pattern 1");
            return state = NodeState.Running;
        }
        else
        {
            if (ChkPlayed)
            {
                Debug.Log("Playing Kill Pattern 1");
                //enable gamecompoenet
                Boss.StartCoroutine(Pattern());
            }
            return state= NodeState.Running;
        }
        
    }
    public IEnumerator Pattern()
    {
        ChkPlayed = false;
        Debug.Log("after coroutine complete");
        yield return new WaitForSeconds(5.0f); //animation end
        Boss.GetComponent<FallingStone>().enabled = true;
        Debug.Log("Create Stone");
        yield return new WaitForSeconds(3.0f);
        Boss.SetPlayKillPattern1(true);
        Debug.Log("End Pattern 1");
    }
}

public class InstantKilAttack2 : Node
{
    //after 10sec, Play Jump 
    BossMonster1 boss;
    bool ChkPlay;
    public InstantKilAttack2() { }
    public InstantKilAttack2(BossMonster1 monster) {
        boss = monster;
        ChkPlay = boss.IsPlayKillPattern2();
    }
    public override NodeState Evaluate()
    {
        if (boss.IsPlayKillPattern2()) {
            Debug.Log("Played kill Pattern 2");
            return state = NodeState.Success;
        }
        else
        {

            if (boss.IsPlayKillPattern1())
            {
                boss.SetPlayKillPattern2(true);
                //boss.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20.0f);
                Debug.Log("Play Kill Pattern 2");
                OnKillPattern();
                boss.SetPlayKillCount(true);
                return state = NodeState.Running;
            }
            return state = NodeState.Running;
        }
    }

    void OnKillPattern()
    {
        boss.GetComponent<BossSpecialGernerate>().enabled = true;
    }
}

public class Dying : Node
{
    Animator Anim;
    Transform t;
    BossMonster1 Boss;
    public Dying() { }
    public Dying(Transform transform) {
        Anim = transform.GetComponent <Animator>();
        t = transform;
    }
    public Dying(BossMonster1 boss)
    {
        Boss = boss;
    }
    public override NodeState Evaluate()
    {
        Boss.Dying();
        return state = NodeState.Success;
    }
}

public class InCloseRange : Node
{
    //Target and This parmeter 
    float Range;

    GameObject Player;
    BossMonster1 boss;
    public InCloseRange() {
        Range = 10.0f;
    }
    public InCloseRange(BossMonster1 boss,  GameObject player, float Range = 10.0f)
    {
        this.boss = boss; 
        this.Player = player;
        this.Range = Range;
    }

    public override NodeState Evaluate()
    {
        Vector3 v = Player.transform.position - boss.transform.position;
        float distance = Vector3.Magnitude(v);
        //Debug.Log(distance);
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
    BossMonster1 boss;
    public JumpAttackPattern() {
    //Get Monster Class
    }
    public JumpAttackPattern(BossMonster1 boss)
    {
        this.boss = boss;
    }
    public override NodeState Evaluate()
    {
        //Realize JumpAttackPattern
        //boss.jumpattack()
        throw new NotImplementedException();
    } 
}
public class AnyAttackCount : Node
{
    BossMonster1 boss;
    int Mode;
    int ChkCount;
    public AnyAttackCount() { }
    public AnyAttackCount(BossMonster1 boss,int ChkCount=5 ,int Mode=1)
    {
        this.boss=boss;
        this.Mode = Mode;
    }
    public override NodeState Evaluate()
    {
        int AnyAttackCount = boss.NormalAttackCount 
            + boss.getJumpAtkCount() + boss.getJumpAtkCount();
        switch (Mode)
        {
            case 1:
                {
                    if (AnyAttackCount < ChkCount)
                    {
                        return state=NodeState.Success;
                    }
                    return state = NodeState.Failure;
                }
            case 2:
                {
                    if(AnyAttackCount >= ChkCount)
                    {
                        return state = NodeState.Success;
                    }
                    return state = NodeState.Failure;
                }
            default:
                Debug.Log("비교 실패 해당 노드는 실패입니다.");
                return state = NodeState.Failure;
        }
            //Normal Attack Count + jump + projectile
        
        throw new NotImplementedException();
    }
}
public class InLongRange : Node
{
    float ChkDistance;
    BossMonster1 boss;
    public InLongRange() { }
    public InLongRange(BossMonster1 boss, float ChkDistance =10.0f) {
        this.boss = boss;
        this.ChkDistance = ChkDistance;
    }
    public override NodeState Evaluate()
    {
        Vector3 v = boss.Player.transform.position - boss.transform.position;
        float Distance = v.magnitude;
        if(Distance>= ChkDistance)
        {
            return NodeState.Success;
        }
        return NodeState.Failure;
        throw new NotImplementedException();
    }
}
public class ProjectileAttackPattern : Node
{
    BossMonster1 Boss;
    Animator Animator;
    float AnimTime;
    public ProjectileAttackPattern() { }
    public ProjectileAttackPattern(BossMonster1 boss)
    {
        Boss = boss;
        Animator = Boss.GetComponentInChildren<Animator>();

        //AnimationClip clip = animator.GetAnimatorTransitionInfo(0);
        //AnimTime = Boss.
    }
    public override NodeState Evaluate()
    {

        Boss.ThrowStone();
        Boss.StartCoroutine(Pattern());
        Boss.AddProjectileAtkCount(1);
        return state = NodeState.Running;
        throw new NotImplementedException();
    }
    IEnumerator Pattern()
    {
        Boss.SetIsAction(true);
        yield return new WaitForSeconds(0.01f);
        AnimTime = Animator.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log("Animation Time : " + AnimTime);
        Debug.Log("start Action");
        yield return new WaitForSeconds(AnimTime);
        Debug.Log("End Action");
        Boss.SetIsAction(false);
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
    Transform Target;
    Transform Center;
    Animator Anim;
    BossMonster1 boss;
    Vector3 GoalPosition;

    public ChasePlayer() { }
    public ChasePlayer(Transform Target, BossMonster1 boss) {
        this.boss = boss;
        this.Target = Target;
        Center = boss.transform;
        Anim = boss.GetComponent<Animator>();
    }
    public ChasePlayer(Transform Target, Transform Center) {
        this.Target = Target;
        this.Center = Center;
        Anim = this.Center.GetComponent<Animator>();
    }
    public ChasePlayer(BossMonster1 boss)
    {
        this.boss = boss;
        Center = boss.transform;
        Target = boss.Player.transform;
        Anim = boss.GetComponent <Animator>();
    }
    public override NodeState Evaluate()
    {
        //Debug.Log("Move To Player");
        Vector3 fv = new Vector3(Target.position.x - Center.position.x,0,0);
        fv.Normalize();
        Debug.Log("Vector :" + fv);
        Center.forward = fv;
        GoalPosition = (fv*boss.speed) + Center.position;
        Center.transform.Translate(Vector3.forward * Time.deltaTime);
        return state = NodeState.Running;
    }

    public IEnumerator Pattern()
    {
        boss.SetIsAction(true);
        yield return new WaitForSeconds(1.5f);
        boss.SetIsAction(false);
    }
}

public class IsAction : Node
{
    BossMonster1 Boss;
    public IsAction(BossMonster1 boss) {
        Boss = boss;
    }
    public override NodeState Evaluate()
    {
        if (Boss.getIsAction())
        {
            Debug.Log("Now actiong");
            return state = NodeState.Failure;
        }
        Debug.Log("No action Next Node");
        return state = NodeState.Success;
        throw new NotImplementedException();
    }
}

