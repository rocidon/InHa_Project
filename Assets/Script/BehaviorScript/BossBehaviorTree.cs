using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviorTree : BehaviorTree
{
    //이곳에서 행동 트리 설정
    protected override Node SetupBehaviorTree()
    {
        Node Root = new SelectorNode();
        return Root;
    }
}
