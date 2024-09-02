using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


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

        /*
        Node Root = new SelectorNode(new List<Node>
        {
            new SequenceNode(new List<Node>
            {
                new ChkTimer(1.5f),
                new SelectorNode(new List<Node>
                {
                    new SequenceNode(new List<Node>
                    {
                        new ChkHeath(Boss),
                        new SelectorNode(new List<Node>
                        {
                            new SequenceNode(new List<Node>
                            {
                                new ChkHeath(Boss),
                                new IsPlayInstantKill(Boss),
                                new InstantKilAttack1(Boss),
                                new InstantKilAttack2(Boss),
                            }),
                            new Dying(Boss)
                        })
                    }),
                    new SelectorNode(new List<Node>
                    {
                        new SelectorNode(new List<Node>
                        {
                            new SequenceNode(new List<Node>
                            {
                                new InCloseRange(Boss, Player, 10.0f),
                                new SelectorNode(new List<Node>
                                {
                                    new SequenceNode(new List<Node>
                                    {
                                        new NormalAttackCount(Boss, 3),
                                        new JumpAttackPattern(Boss)
                                    }),
                                    new SequenceNode(new List<Node>
                                    {
                                        new AnyAttackCount(Boss, 5, 1),
                                        new NormalAttack()
                                    })
                                })
                            }),
                            new SequenceNode(new List<Node>
                            {
                            new InLongRange(Boss),
                            new AnyAttackCount(Boss, 5, 1),
                            new ProjectileAttackPattern(Boss)
                            })
                        }),
                        new SelectorNode(new List<Node>
                        {
                            //스페셜 공격 부분
                        })
                    }),
                    //set target and Center                    
                })
            }),
            new SequenceNode(new List<Node>
            {
              new ChkTimer(0.5f),
              new ChasePlayer(Boss)
             }),
             
             new IDLE(Boss)
        });
        //*/
        ///*
        Node Root = new SelectorNode(new List<Node>
        {
            //Running상태면 같이 실행된다고 생각하면 될거 같다.
           //new InCloseRange(Player.transform, Boss.transform, 5),
           //new SequenceNode(new List<Node> {
           //     new ProjectileAttackPattern(_Boss)
           
           //}),

           new SequenceNode(new List<Node>
           {
              new ChkTimer(1.0f),
              new IsAction(Boss),
              new InLongRange(Boss,4),
              new ProjectileAttackPattern(Boss)
           }),
           new SelectorNode(new List<Node>
           {
                new SequenceNode(new List<Node>
                {
                    new IsAction(Boss),
                    new InCloseRange(Boss, Player, 1),
                    new IDLE()
                }),
                new SequenceNode(new List<Node>
                {
                    new IsAction(Boss),
                    new ChasePlayer(Boss)
                })
           })
        });
        //*/
        return Root;
    }
}
