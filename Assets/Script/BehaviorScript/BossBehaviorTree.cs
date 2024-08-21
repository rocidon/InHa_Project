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
    //이곳에서 행동 트리 설정
    protected override Node SetupBehaviorTree()
    {
        Node Root = new SelectorNode(new List<Node>
        {

            new TestNode()
        });
        return Root;
    }
}

//이 밑에 원하는 행동 노드를 만들어두기
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