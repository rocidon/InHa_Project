using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster1 : BossBehaviorTree
{
    public int NormalAttackCount;
    public int BossCount;
    public GameObject Stone;
    bool InstantKillPattern;
    bool isPlayKillPattern1;
    bool isPlayKillPattern2;
    int JumpAttackCount;
    int ProjectileAttackCount;
    
    public enum ANIMATIONVALUE
    {
        IDLE,
        NORMALATTACK,
        PROJECTILEATTACK,
        WALKING
    }
    void Start()
    {
        //Debug.Log("Start BossMonster1");
        //_Health = 1000f;
        Isaction = false;
        _MaxHealth = 1000f;
        _Atk = 100f;
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
        _Health = _MaxHealth;
        //Value setting Before this Line
        SetRootNode();
    }

    void Update()
    {
        //if()
        PlayTree();
        //_Health -= 10;
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
        
        base.Dying();
    }
    public bool IsPlayKillPattern2() { 
        return isPlayKillPattern2;
    }

    public void ThrowStone()
    {
        float px = transform.localScale.x;
        float py = transform.GetComponent<CapsuleCollider>().height;
        Vector3 p = transform.position;
        p += transform.forward;
        p += new Vector3(0, py, 0);
        Instantiate(Stone, p , Quaternion.Euler(0, 0, 0));
    }

    public int getJumpAtkCount()
    {
        return JumpAttackCount;
    }
    public int getProjectileAtkCount()
    {
        return ProjectileAttackCount;
    }
    public void AddProjectileAtkCount(int val)
    {
        ProjectileAttackCount += val;
    }
    public bool getIsAction()
    {
        return Isaction;
    }
    public void SetIsAction(bool val)
    {
        Isaction = val;
    }
}


