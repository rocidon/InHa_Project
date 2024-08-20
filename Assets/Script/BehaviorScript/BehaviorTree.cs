using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tree 원형
//트리의 경우 Root를 가진 채 유니티에서 Update에서 각 노드를 평가해주면 된다.
//출처 : https://husk321.tistory.com/412
public abstract class BehaviorTree : MonoBehaviour
{
    Node RootNode;
    protected abstract Node SetupBehaviorTree();
    protected void Start()
    {
        RootNode = SetupBehaviorTree();
    }

    protected void Update()
    {
        if (RootNode is null) return;
        RootNode.Evaluate();
    }
}
