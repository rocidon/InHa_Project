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
        PlayTree();
        _Health -= 10;
    }
}


