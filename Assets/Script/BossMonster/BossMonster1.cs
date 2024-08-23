using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster1 : BossBehaviorTree
{
    public int NormalAttackCount;
    void Start()
    {
        //Debug.Log("Start BossMonster1");
        _Health = 1000f;
        _Atk = 100f;
        _Def = 20f;
        Player = GameObject.FindWithTag("Player");
        Boss = this;

        SetRootNode();
        NormalAttackCount = 0;
    }

    void Update()
    {
        PlayTree();
        //_Health -= 10;
    }
}


