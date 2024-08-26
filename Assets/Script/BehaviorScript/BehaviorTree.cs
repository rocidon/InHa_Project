using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tree ����
//Ʈ���� ��� Root�� ���� ä ����Ƽ���� Update���� �� ��带 �����ָ� �ȴ�.
//��ó : https://husk321.tistory.com/412
public abstract class BehaviorTree : Monster
{
    protected Node RootNode;
    protected abstract Node SetupBehaviorTree();
    protected void SetRootNode()
    {
        Debug.Log("Tree Parent Run");
        RootNode = SetupBehaviorTree();
        Debug.Log("Set Tree");
    }
    protected void PlayTree()
    {
        if (RootNode is null) return;
        Node.NodeTimer += Time.deltaTime;
        //RootNode.NodeTimer += Time.deltaTime;
        RootNode.Evaluate();
        //Debug.Log("Timer : " + TreeTimer);
    }
}
