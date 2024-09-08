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
    //private void Awake()
    //{
    //    _Health = 1000f;
    //    _Atk = 100f;
    //    _Def = 100f;
    //}
    //이곳에서 행동 트리 설정
    protected override Node SetupBehaviorTree()
    {
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
                           new InstantKilAttack1(Boss),
                           new InstantKilAttack2(Boss)
                       })
                   }),
                   new SelectorNode(new List<Node>
                   {
                       new SequenceNode(new List<Node>
                       {
                            new InCloseRange(Boss, Player, 3),
                            new SelectorNode(new List<Node>
                            {
                                new SequenceNode(new List<Node>
                                {
                                    new InLongRange(Boss, 1.5f),
                                    //new NormalAttackCount(Boss, 1),
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
                           new InLongRange(Boss, 10),
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
                                  // new SelectSpeicalPattern(Boss),
                                   new SpecialAttackPattern1(Boss)
                               }),
                               new SpecialAttackPattern2(Boss)
                           })
                       })
                   })
               })
           }),
           new SelectorNode(new List<Node>
           {
               new SequenceNode(new List<Node>
               {
                   new InCloseRange(Boss, Player, 1.5f),
                   new IDLE(Boss)
               }),
               new ChasePlayer(Boss)
           })
        });
        //*/
        return Root;
    }
}
