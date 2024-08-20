using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tree ����
//Ʈ���� ��� Root�� ���� ä ����Ƽ���� Update���� �� ��带 �����ָ� �ȴ�.
//��ó : https://husk321.tistory.com/412
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
