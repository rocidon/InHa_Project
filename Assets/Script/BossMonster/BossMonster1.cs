using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster1 : BossBehaviorTree
{
    void Start()
    {
        _Health = 1000f;
        _Atk = 100f;
        _Def = 20f;
        SetRootNode();
    }

    void Update()
    {
        //Debug.Log("This is BossMonster1");
        PlayTree();
        //if (RootNode is null) return;
        //RootNode.Evaluate();
    }
}


