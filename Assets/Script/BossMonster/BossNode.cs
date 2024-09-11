using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


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
        boss.SetStandardMotion(BossMonster1.StandardMotion.Idle);
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
    BossMonster1 Boss;
    Animator Animator;
    float AnimTime;
    public NormalAttack() {
        
    }
    public NormalAttack(BossMonster1 boss) {
        this.Boss = boss;
        Animator = Boss.GetComponentInChildren<Animator>();
    }

    public override NodeState Evaluate()
    {

        //Write Animator Parmeter value setting
        //boss.NormalAttack()
        Boss.StartCoroutine(Pattern());
        return state = NodeState.Running;
    }
    IEnumerator Pattern()
    {
        Boss.SetIsAction(true);
        Animator.SetBool("IsNormalAttack", true);      
        Boss.SetCurrentMotion(false);
        yield return new WaitForSeconds(0.1f);

        AnimTime = Animator.GetCurrentAnimatorStateInfo(0).length;

        //Debug.Log("Animation Time : " + AnimTime);
        Debug.Log("start Normal ATk Action");

        yield return new WaitForSeconds(AnimTime - 0.93f);
        Debug.Log("End Action");
        //구현부
        Boss.NormalAttack();
        //
        Boss.AddNormalAtkCount(1);
        yield return new WaitForSeconds(0.93f);
        Animator.SetBool("IsNormalAttack", false);
        Boss.SetCurrentMotion(true);

        Boss.SetIsAction(false);
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
        boss.SetIsAction(true);
        return state = NodeState.Success;
    }
}
public class InstantKilAttack1 : Node
{
    GameObject FootHold;
    BossMonster1 Boss;
    Animator animator;
    float AnimTime;
    public InstantKilAttack1() { }
    public InstantKilAttack1(BossMonster1 boss) {
        Boss = boss;
        animator = Boss.GetComponentInChildren<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Playing Kill Pattern 1");
        //enable gamecompoenet
        Boss.StartCoroutine(Pattern());

        return state = NodeState.Running;
    }
    public IEnumerator Pattern()
    {
        animator.SetBool("IsInstantKillPattern1", true);
        Boss.SetCurrentMotion(false);
        yield return new WaitForSeconds(0.1f);
        //Play Kill Pattern 1
        AnimTime = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime/2);
        /*Play about Instant Kill Pattern1*/
        Boss.GetComponent<FallingStone>().enabled = true;
        Debug.Log("Create Stone");
        /*--------------------------------*/
        yield return new WaitForSeconds(AnimTime / 2);

        animator.SetBool("IsStartInstantPattern", true);        
        yield return new WaitForSeconds(0.1f);
        //Play Roar Animation
        AnimTime = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime-0.1f);
        //End Pattern 1

        //Boss.SetPlayKillPattern1(true);
        Debug.Log("End Pattern 1");
        /*----- Paste Pattern 2 */

        animator.SetBool("IsInstantKillPattern2", true);
        //wait for Change Animation Pattern1 to Pattern2
        yield return new WaitForSeconds(0.1f);
        //Get Anmation Time of Pattern2 
        AnimTime = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime / 2);
        /*Pattern Start*/
        Boss.GetComponent<BossSpecialGernerate>().enabled = true;
        /*-------------*/
        yield return new WaitForSeconds(AnimTime / 2);
        //Kill Pattern End
        animator.SetBool("IsStartInstantPattern", false);
        animator.SetBool("IsInstantKillPattern1", false);
        animator.SetBool("IsInstantKillPattern2", false);
        Boss.SetCurrentMotion(true);
        Boss.SetIsAction(false);
        Boss.SetPlayKillCount(true);
    }
}

public class InstantKilAttack2 : Node
{
    //after 10sec, Play Jump 
    BossMonster1 boss;
    Animator animator;
    float AnimTime;
    public InstantKilAttack2() { }
    public InstantKilAttack2(BossMonster1 monster) {
        boss = monster;
        animator = boss.GetComponentInChildren<Animator>();
    }
    public override NodeState Evaluate()
    {
        Debug.Log("Play Kill Pattern 2");
        boss.StartCoroutine(Pattern());
        
        return state = NodeState.Running;
    }
    IEnumerator Pattern()
    {
        animator.SetBool("IsInstantKillPattern2", true);
        //wait for Change Animation Pattern1 to Pattern2
        yield return new WaitForSeconds(0.1f);
        //Get Anmation Time of Pattern2 
        AnimTime = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime/2);
        /*Pattern Start*/
        boss.GetComponent<BossSpecialGernerate>().enabled = true;
        /*-------------*/
        yield return new WaitForSeconds(AnimTime / 2);
        //Kill Pattern End
        animator.SetBool("IsStartInstantPattern", false);
        animator.SetBool("IsInstantKillPattern1", false);
        animator.SetBool("IsInstantKillPattern2", false);
        boss.SetCurrentMotion(true);
        boss.SetIsAction(false);
        boss.SetPlayKillCount(true);
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
        if(boss.getNormalAtkCount() > ChkCount)
        {
            boss.AddNormalAtkCount(boss.getNormalAtkCount()*-1);
            return state = NodeState.Success;
        }
        return state = NodeState.Failure;
    }




}
public class JumpAttackPattern : Node
{
    BossMonster1 boss;
    Animator Animator;
    float AnimTime;
    public JumpAttackPattern() {
    //Get Monster Class
    }
    public JumpAttackPattern(BossMonster1 boss)
    {
        this.boss = boss;
        Animator = boss.GetComponentInChildren<Animator>();
    }
    public override NodeState Evaluate()
    {
        //Realize JumpAttackPattern
        //boss.jumpattack()
        boss.StartCoroutine(Pattern());
        return state = NodeState.Running;
        throw new NotImplementedException();
    }
    IEnumerator Pattern()
    {
        boss.SetIsAction(true);
        Animator.SetBool("IsJumpAttack", true);
        boss.SetCurrentMotion(false);
        // Animator.SetBool("IsIdle", false);    

        yield return new WaitForSeconds(0.1f);

        AnimTime = boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;

        Debug.Log("Animation Time : " + AnimTime);
        Debug.Log("start Jump Atk Action");

        float MoveDistance = Vector3.Magnitude(boss.transform.position - boss.Player.transform.position) - 1.5f;

        float Dtime = Time.deltaTime;
        while(AnimTime - 2.6f >= Dtime)
        {
            float DeltaTime = Time.deltaTime;
            //이동할 거리 / 걸리는 시간 = 움직일 속도
            float DSpeed = MoveDistance / (AnimTime - 2.6f);
            boss.transform.Translate(Vector3.forward * DeltaTime * DSpeed);
            Dtime += DeltaTime;
            yield return new WaitForSeconds(DeltaTime);
        }

        Dtime -= (AnimTime - 2.4f);
        //yield return new WaitForSeconds(AnimTime - 2.4f);

        Debug.Log("End Action");
        /*이곳에서 충돌처리하게 만들어줘야함*/
        boss.JumppAttack();
        boss.AddJumpAtkCount(1);
        yield return new WaitForSeconds(2.6f - Dtime);
        Animator.SetBool("IsJumpAttack", false);
        //  Animator.SetBool("IsIdle", true);
        boss.SetCurrentMotion(true);
        boss.SetIsAction(false);
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
        this.ChkCount = ChkCount;
    }
    public override NodeState Evaluate()
    {
        int AnyAttackCount = boss.getNormalAtkCount()
            + boss.getJumpAtkCount() + boss.getProjectileAtkCount();
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
        Debug.Log("던지기");

        Boss.StartCoroutine(Pattern());
        return state = NodeState.Running;
        throw new NotImplementedException();
    }
    IEnumerator Pattern()
    {
        Boss.SetIsAction(true);
        Animator.SetBool("IsProjectileAttack", true);
        // Animator.SetBool("IsIdle", false);      
        Boss.SetCurrentMotion(false);
        yield return new WaitForSeconds(0.1f);

        AnimTime = Boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;

        Debug.Log("Animation Time : " + AnimTime);
        Debug.Log("start Action");

        yield return new WaitForSeconds(AnimTime-1.0f);

        Boss.ThrowStone();

        Boss.AddProjectileAtkCount(1);
        yield return new WaitForSeconds(1.0f);
        Animator.SetBool("IsProjectileAttack", false);
        //Animator.SetBool("IsIdle", true);
        Boss.SetCurrentMotion(true);
        Boss.SetIsAction(false);
    }

}
public class SpecialAttackPattern1 : Node
{
    BossMonster1 boss;
    Animator Animator;
    float AnimTime;
    public SpecialAttackPattern1() { }
    public SpecialAttackPattern1(BossMonster1 boss) {
        this.boss = boss;
        Animator = boss.GetComponentInChildren<Animator>();
    }
    public override NodeState Evaluate()
    {
        boss.StartCoroutine(Pattern());
        return state = NodeState.Success;
        throw new NotImplementedException();
    }

    IEnumerator Pattern()
    {
        boss.SetIsAction(true);
        Animator.SetBool("IsSpeicalReady", true);        
        boss.SetCurrentMotion(false);

        yield return new WaitForSeconds(0.1f);

        AnimTime = boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime); //wait for roar

        Animator.SetBool("IsSpeicalAttack1", true);    

        yield return new WaitForSeconds(0.1f);
        Debug.Log("Animation Time : " + AnimTime);
        Debug.Log("start Speical 1 Atk Action");
        AnimTime = boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(AnimTime/2);

        Debug.Log("End Action");

        /*패턴 실행*/
        boss.SpeicalAttack1();
        
        yield return new WaitForSeconds(AnimTime / 2);
        Animator.SetBool("IsSpeicalReady", false);
        Animator.SetBool("IsSpeicalAttack1", false);
        boss.SetCurrentMotion(true);

        boss.SetIsAction(false);
    }
}
public class SpecialAttackCount : Node
{
    public SpecialAttackCount() { }
    public SpecialAttackCount(BossMonster1 boss, int ChkCount=3) { }
    public override NodeState Evaluate()
    {
        throw new NotImplementedException();
    }
}
public class SpecialAttackPattern2 : Node
{
    BossMonster1 boss;
    Animator Animator;
    float AnimTime;
    public SpecialAttackPattern2() { }
    public SpecialAttackPattern2(BossMonster1 boss) {
        this.boss = boss;
        Animator = boss.GetComponentInChildren<Animator>();
    }
    public override NodeState Evaluate()
    {
        boss.StartCoroutine(Pattern());
        return state = NodeState.Success;
        throw new NotImplementedException();
    }
    IEnumerator Pattern()
    {
        boss.SetIsAction(true);

        Animator.SetBool("IsSpeicalReady", true);
        Animator.SetBool("BackJumpStart", true);
        Animator.SetBool("BackJump-ing", true);

        boss.SetCurrentMotion(false);

        yield return new WaitForSeconds(0.1f);
        AnimTime = boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime); //wait roar
        yield return new WaitForSeconds(0.1f);
        AnimTime = boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime- 1.1f); //wait jumpstart

        //jump-ing
        Vector3 StartPos = boss.transform.position;
        float MoveDistance = 5.0f;
        //float Theta60 = 60.0f * 3.141592f / 180.0f;
        float Dtime = Time.deltaTime;
        while (1.0f >= Dtime)
        {
            float DeltaTime = Time.deltaTime;
            //이동에 필요한 시간? 
            float DSpeed = MoveDistance/ 1.0f;
            float dx = Mathf.Abs(StartPos.x - boss.transform.position.x+0.01f);
            float dy = dx * (dx - MoveDistance) * -1;
            //dy *= 2.0f;
            //dy = dy != 0 ? dy / Mathf.Abs(dy) : dy;
            //Debug.Log(dy);
            boss.transform.Translate(Vector3.back * DeltaTime * DSpeed);
            boss.transform.position = new Vector3(boss.transform.position.x, StartPos.y + dy, boss.transform.position.z);
            Dtime += DeltaTime;
            yield return new WaitForSeconds(DeltaTime);
        }

        boss.transform.position = new Vector3(boss.transform.position.x, StartPos.y, boss.transform.position.z);
        Animator.SetBool("BackJumpEnd", true);
        yield return new WaitForSeconds(0.1f);
        AnimTime = boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(AnimTime - 0.1f);

        Animator.SetBool("IsSpeicalAttack2", true);
        yield return new WaitForSeconds(0.1f);
        AnimTime = boss.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Debug.Log("Speical 2 Anim Time : "+ AnimTime);
        Debug.Log("start Speical 2 Atk Action");
        yield return new WaitForSeconds(AnimTime -2.4f);

        Debug.Log("End Action");

        /*이곳에서 충돌처리하게 만들어줘야함*/
        boss.SpeicalAttack2();

        yield return new WaitForSeconds(2.4f);

        //all animation off
        Animator.SetBool("IsSpeicalReady", false);
        Animator.SetBool("BackJumpStart", false);
        Animator.SetBool("BackJump-ing", false);
        Animator.SetBool("BackJumpEnd", false);
        Animator.SetBool("IsSpeicalAttack2", false);

        boss.SetCurrentMotion(true);

        boss.SetIsAction(false);
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
        Debug.Log("Move To Player");
        boss.transform.Translate(Vector3.forward * Time.deltaTime*1.0f);
        boss.SetStandardMotion(BossMonster1.StandardMotion.Movement);
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
    Transform Target;
    Transform Center;
    BossMonster1 Boss;
    public IsAction(BossMonster1 boss) {
        Boss = boss;
        Center = boss.transform;
        Target = boss.Player.transform;
    }
    public override NodeState Evaluate()
    {
        if (Boss.getIsAction())
        {
            Debug.Log("Now actiong");

            return state = NodeState.Success;
        }
        Debug.Log("No action Next Node");
        Vector3 fv = new Vector3(Target.position.x - Center.position.x, 0, 0);
        fv.Normalize();
        Boss.transform.forward = fv;
        return state = NodeState.Failure;
        throw new NotImplementedException();
    }
}

public class SelectSpeicalPattern : Node
{
    int SelectNumber;
    BossMonster1 boss;
    public SelectSpeicalPattern() {
        SelectNumber = UnityEngine.Random.Range(0,11);
    }
    public SelectSpeicalPattern(BossMonster1 boss)
    {
        this.boss = boss;
        
        
    }
    public override NodeState Evaluate()
    {
        SelectNumber = UnityEngine.Random.Range(0, 11);
        boss.ResetCommonAtkCount();
        Debug.Log("Select Number : " + SelectNumber);
        if (SelectNumber < 5)
        {
            Debug.Log("Play Speical Attack 1");
            return state = NodeState.Success;
        }
        Debug.Log("Play Speical Attack 2");
        return state = NodeState.Failure;
        throw new NotImplementedException();
    }
}