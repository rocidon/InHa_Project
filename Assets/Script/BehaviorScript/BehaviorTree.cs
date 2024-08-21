using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tree ����
//Ʈ���� ��� Root�� ���� ä ����Ƽ���� Update���� �� ��带 �����ָ� �ȴ�.
//��ó : https://husk321.tistory.com/412
public abstract class BehaviorTree : Monster
{
    protected float TreeTimer;
    protected Node RootNode;
    protected abstract Node SetupBehaviorTree();
    protected void SetRootNode()
    {
        Debug.Log("Tree Parent Run");
        RootNode = SetupBehaviorTree();
    }
    protected void PlayTree()
    {
        TreeTimer += Time.deltaTime;
        if (RootNode is null) return;
        RootNode.Evaluate();
        //Debug.Log("Timer : " + TreeTimer);
    }
}
