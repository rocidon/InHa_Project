using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviorTree : BehaviorTree
{
    //�̰����� �ൿ Ʈ�� ����
    protected override Node SetupBehaviorTree()
    {
        Node Root = new SelectorNode();
        return Root;
    }
}
