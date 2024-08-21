using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBehaviorTree : BehaviorTree
{
    //private void Awake()
    //{
    //    _Health = 1000f;
    //    _Atk = 100f;
    //    _Def = 100f;
    //}
    //�̰����� �ൿ Ʈ�� ����
    protected override Node SetupBehaviorTree()
    {
        Node Root = new SelectorNode(new List<Node>
        {

            new TestNode()
        });
        return Root;
    }
}

//�� �ؿ� ���ϴ� �ൿ ��带 �����α�
public class TestNode : Node
{
    public TestNode()
    {
        //Debug.Log("This is TestNode");
    }
    public override NodeState Evaluate()
    {
        Debug.Log("This is TestNode Running");
        return state = NodeState.Running;
    }
}