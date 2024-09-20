using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class BossBehaviorTree : BehaviorTree
{
    public GameObject Player;
    //protected Monster Boss;
    protected BossMonster1 Boss;
    float LongRange;
    float CloseRange;
    float JumpRange;
    private void Init()
    {
        Transform NormalObj = Boss.transform.GetChild(2);
        Transform JumpObj = Boss.transform.GetChild(1);
        CloseRange = Boss.transform.localScale.z * NormalObj.localPosition.z
            + Boss.transform.localScale.z * NormalObj.GetComponent<BoxCollider>().size.z/2;
        JumpRange = Boss.transform.localScale.z *JumpObj.GetComponent<BoxCollider>().size.z;
        LongRange = JumpRange*2;

        Debug.Log("근거리" + CloseRange);
        Debug.Log("점프" + JumpRange);
        Debug.Log("원거리" + LongRange);
    }
    //이곳에서 행동 트리 설정
    protected override Node SetupBehaviorTree()
    {
        Init();
        ///*
        Node Root = new SelectorNode(new List<Node>
        {
           new IsAction(Boss),
           new SequenceNode(new List<Node>
           {
               new ChkTimer(1.5f),
               new SelectorNode(new List<Node>
               {
                   new SequenceNode(new List<Node>
                   {
                       new ChkHeath(Boss),
                       new SequenceNode(new List<Node>
                       {
                           new IsPlayInstantKill(Boss),
                           new InstantKilAttack1(Boss)
                       })
                   }),
                   new SelectorNode(new List<Node>
                   {
                       new SequenceNode(new List<Node>
                       {
                            new InCloseRange(Boss, Player, JumpRange),
                            new SelectorNode(new List<Node>
                            {
                                new SequenceNode(new List<Node>
                                {
                                    new InLongRange(Boss, CloseRange),
                                    new JumpAttackPattern(Boss)
                                }),
                                new SequenceNode(new List<Node>
                                {
                                    new AnyAttackCount(Boss, 5, 1),
                                    new NormalAttack(Boss)
                                })
                            })
                       }),
                       new SequenceNode(new List<Node>
                       {
                           new InLongRange(Boss, LongRange),
                           new ProjectileAttackPattern(Boss)
                       })
                   }),
                   new SelectorNode(new List<Node>
                   {
                       new SequenceNode(new List<Node>
                       {
                           new AnyAttackCount(Boss, 5, 2),
                           new SelectorNode(new List<Node>
                           {
                               new SequenceNode(new List<Node>
                               {
                                   new SelectSpeicalPattern(Boss),
                                   new SpecialAttackPattern1(Boss),                                   
                               }),
                               new SpecialAttackPattern2(Boss)
                              // new SpecialAttackPattern1(Boss)
                           })
                       })
                   })
               })
           }),
           new SelectorNode(new List<Node>
           {
               new SequenceNode(new List<Node>
               {
                   new InCloseRange(Boss, Player, CloseRange),
                   new IDLE(Boss)
               }),
               new ChasePlayer(Boss)
           })
        });
        //*/
        return Root;
    }
}
