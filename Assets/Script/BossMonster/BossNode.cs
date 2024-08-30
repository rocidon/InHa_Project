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
    public TestNode()
    {
        //Debug.Log("This is TestNode");
    }
    public TestNode(BossMonster1 boss)
    {
        this.boss = boss;
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
                
                boss.SetPlayKillCount(true);
                return state = NodeState.Running;
            }
            return state = NodeState.Running;
        }
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
    Transform Target;
    Transform Center;
    Animator Anim;
    BossMonster1 boss;

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
    public override NodeState Evaluate()
    {
        Debug.Log("Move");
        Vector3 fv = new Vector3(Target.position.x - Center.position.x,0,0);
        fv.Normalize();
        Debug.Log(fv);
        Center.forward = fv;
        Center.transform.Translate(Vector3.forward * Time.deltaTime * 2);
        //Center.position = Vector3.Lerp(Center.position, Target.position, Time.deltaTime);
        if (boss.IsPlayKillPattern1())
        {
            Debug.Log("Play Complete Pattern 1 and Now Playing Pattern 2");
        }
        else
        {
            Debug.Log("No Play Pattern 1 This is Pattern 2");
        }
        //set Animation Parameter value

        return state = NodeState.Running;
;
    }
}