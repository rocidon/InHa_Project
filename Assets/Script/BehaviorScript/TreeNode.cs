using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Node상태와 Node를 상속받는 기본 class들이 모여있는 곳
public enum NodeState
{
    Running,
    Success,
    Failure
}

public abstract class Node
{
    protected NodeState state;
    public Node parentNode;
    protected List<Node> childrenNode = new List<Node>();
    public static float NodeTimer;
    //public float NodeTimer;
    public Node()
    {
        parentNode = null;
        NodeTimer = 0f;
        //Anim = t
    }
    public Node(List<Node> children)
    {
        foreach (Node child in children)
        {
            AttachChild(child);
        }
    }
    public void AttachChild(Node child)
    {
        childrenNode.Add(child);
        child.parentNode = this;
    }
    public abstract NodeState Evaluate();
}

public class SequenceNode : Node
{
    public SequenceNode() : base() { }
    
    public SequenceNode(List<Node> children) : base(children) { }
    public override NodeState Evaluate()
    {
        bool bNowRunning = false;
        foreach (Node node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case NodeState.Failure:
                    return state = NodeState.Failure;
                case NodeState.Success:
                    continue;
                case NodeState.Running:
                    bNowRunning = true;
                    continue;
                default:
                    continue;
            }
        }

        return state = bNowRunning ? NodeState.Running : NodeState.Success;
    }
}

public class SelectorNode : Node
{
    public SelectorNode() : base() { }
    public SelectorNode(List<Node> children) : base(children) { }
    public override NodeState Evaluate()
    {
        foreach (Node node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case NodeState.Failure:
                    continue;
                case NodeState.Success:
                    return state = NodeState.Success;
                case NodeState.Running:
                    return state = NodeState.Running;
                default:
                    continue;
            }
        }
        return state = NodeState.Failure;
    }
}
