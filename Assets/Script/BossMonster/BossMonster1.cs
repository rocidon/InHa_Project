using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster1 : BossBehaviorTree
{
    public enum StandardMotion
    {
        Idle,
        Movement
    }
    public enum ANIMATIONVALUE
    {
        IDLE,
        NORMALATTACK,
        PROJECTILEATTACK,
        WALKING
    }

    public int NormalAttackCount;
    public int BossCount;
    public GameObject Stone;

    StandardMotion currentMotion;
    bool InstantKillPattern;
    bool isPlayKillPattern1;
    bool isPlayKillPattern2;
    int JumpAttackCount;
    int ProjectileAttackCount;
    int SpecialAttackCount;


    void Start()
    {
        //Debug.Log("Start BossMonster1");
        //_Health = 1000f;
        currentMotion = StandardMotion.Idle;
        Isaction = false;
        _MaxHealth = 1000f;
        _Atk = 5.0f;
        _Def = 20f;
        Player = GameObject.FindWithTag("Player");
        Boss = this;
        IsDying = false;
        InstantKillPattern = false;
        NormalAttackCount = 0;
        isPlayKillPattern1 = false;
        isPlayKillPattern2 = false;
        speed = 5.0f;
        BossCount = 0;
        JumpAttackCount = 0;
        ProjectileAttackCount = 0;
        SpecialAttackCount = 0;
        _Health = _MaxHealth;

        animator = GetComponentInChildren<Animator>();
        //Value setting Before this Line
        SetRootNode();
    }

    void Update()
    {
        if (!IsDying)
        {
            PlayTree();
            //TakeDamage(10);
        }
        
    }
    public void SetPlayKillPattern1(bool val) { isPlayKillPattern1 = val; }
    public void SetPlayKillPattern2(bool val) { isPlayKillPattern2 = val; }
    public void SetPlayKillCount(bool val) { InstantKillPattern = val; }
    public bool GetInstantKillCount()
    {
        return InstantKillPattern;
    }
    public bool IsPlayKillPattern1()
    {
        return isPlayKillPattern1;
    }
    public override void Dying()
    {
        animator.SetTrigger("IsDying");
        StartCoroutine(WAIT());
        //base.Dying();
    }
    IEnumerator WAIT()
    {
        yield return new WaitForSeconds(0.1f);
        float time = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(time);
        base.Dying();
    }
    public override void TakeDamage(float damage)
    {
        //Debug.Log("!!!!!!");
        _Health -= damage;
        if(_Health <= 0.0f)
        {
            IsDying = true;
            Dying();
        }
    }
    public bool IsPlayKillPattern2() { 
        return isPlayKillPattern2;
    }

    public void ThrowStone()
    {
        float px = transform.localScale.x;
        float py = transform.GetComponent<CapsuleCollider>().height * transform.localScale.y;
        Vector3 p = transform.position;
        p += transform.forward;
        p += new Vector3(0, py, 0);
        Instantiate(Stone, p , Quaternion.Euler(0, 0, 0));
    }
    public int getNormalAtkCount()
    {
        return NormalAttackCount;
    }
    public int getSpecialAtkCount()
    {
        return SpecialAttackCount;
    }
    public int getJumpAtkCount()
    {
        return JumpAttackCount;
    }
    public int getProjectileAtkCount()
    {
        return ProjectileAttackCount;
    }
    public void AddNormalAtkCount(int val)
    {
        NormalAttackCount += val;
    }
    public void AddSpecialAtkCount(int val)
    {
        SpecialAttackCount += val;
    }
    public void AddJumpAtkCount(int val)
    {
        JumpAttackCount += val;
    }
    public void AddProjectileAtkCount(int val)
    {
        ProjectileAttackCount += val;
    }

    public void ResetCommonAtkCount()
    {
        Debug.Log("Reset common Attack Count");
        JumpAttackCount = 0;
        ProjectileAttackCount = 0;
        NormalAttackCount = 0;
    }
    public bool getIsAction()
    {
        return Isaction;
    }
    public void SetIsAction(bool val)
    {
        Isaction = val;
    }

    public void SetStandardMotion(StandardMotion Mot)
    {
        currentMotion = Mot;
        switch (Mot)
        {
            case StandardMotion.Idle:
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", true);

                break;
            case StandardMotion.Movement:
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsIdle", false);
                break;
            default:
                Debug.Log("허용되지 않은 idle 모션 값");
                break;
        }
    }
    public void SetCurrentMotion(bool val)
    {
        switch (currentMotion)
        {
            case StandardMotion.Idle:
                animator.SetBool("IsIdle", val);
                break;
            case StandardMotion.Movement:
                animator.SetBool("IsWalking", val);
                break;
            default:
                Debug.Log("허용되지 않은 idle 모션 값");
                break;
        }
    }

    public void JumppAttack()
    {
        GameObject jumAtk = transform.GetChild(1).gameObject;
        if(jumAtk.name == "JumpAttack")//유효성 검사
        {
            BossJumpAtk BJA = jumAtk.GetComponent<BossJumpAtk>();
            BJA.OnAtk();
        }
        else
        {
            Debug.Log("잘못된 인덱스 접근 : Not " + "JumpAttack");
        }
    }

    public void NormalAttack()
    {
        GameObject Atk = transform.GetChild(2).gameObject;
        if (Atk.name == "NormalAttack")//유효성 검사
        {
            BossNormalAttack NAtk = Atk.GetComponent<BossNormalAttack>();
            NAtk.OnAtk();
        }
        else
        {
            Debug.Log("잘못된 인덱스 접근 : Not " + "NormalAttack");
        }
    }

    public void SpeicalAttack1()
    {
        BossSpecialAttackver1 SAtk = GetComponent<BossSpecialAttackver1>();
        if(SAtk != null)
        {
            SAtk.OnAtk();
        }
        else
        {
            Debug.Log("No compoenet BossSpecialAttackver1 Add Compoenet");
        }
    }

    public void SpeicalAttack2() 
    {
        BossSpecialAttackver2 SAtk = GetComponent<BossSpecialAttackver2>();
        if(SAtk != null)
        {
            SAtk.OnAtk();
        }
        else
        {
            Debug.Log("No compoenet BossSpecialAttackver1 Add Compoenet");
        }
    }
}


