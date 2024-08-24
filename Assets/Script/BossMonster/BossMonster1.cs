using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster1 : BossBehaviorTree
{
    public int NormalAttackCount;
    bool InstantKillPattern;
    bool isPlayKillPattern1;
    bool isPlayKillPattern2;
    void Start()
    {
        //Debug.Log("Start BossMonster1");
        _Health = 1000f;
        _Atk = 100f;
        _Def = 20f;
        Player = GameObject.FindWithTag("Player");
        Boss = this;
        InstantKillPattern = false;
        NormalAttackCount = 0;
        isPlayKillPattern1 = false;
        isPlayKillPattern2 = false;
        _Boss = this;

        //Value setting Before this Line
        SetRootNode();
    }

    void Update()
    {
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
    public bool IsPlayKillPattern2() { 
        return isPlayKillPattern2;
    }
}


