using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class BossBehaviorTree : BehaviorTree
{
    public GameObject Player;
    protected Monster Boss;
    //private void Awake()
    //{
    //    _Health = 1000f;
    //    _Atk = 100f;
    //    _Def = 100f;
    //}
    //이곳에서 행동 트리 설정
    protected override Node SetupBehaviorTree()
    {
        /*Node Root = new SelectorNode(new List<Node>
        {
            new SequenceNode(new List<Node>
            {
                new ChkHeath(Boss),
                new SelectorNode(new List<Node>
                {
                    new SequenceNode(new List<Node>
                    {
                        new ChkHeath(Boss),
                        new InstantKilAttack1(),
                        new InstantKilAttack2()
                    }),
                    new Dying()
                })
            }),
            new SequenceNode(new List<Node>
            {
                new ChkTimer(3.0f),
                new SelectorNode(new List<Node>
                {
                    new SelectorNode(new List<Node>
                    {
                        new SequenceNode(new List<Node>
                        {
                            //add inCloseRangeNode here
                            new InCloseRange(),

                            new SelectorNode(new List<Node>
                            {
                                new SequenceNode(new List<Node>
                                {
                                    //add NormalAttackCount Node here
                                    new NormalAttackCount(),

                                    //add jumpAttackPattern Node here
                                    new JumpAttackPattern()
                                }),
                                new SequenceNode(new List<Node>
                                {
                                    //add Any Attack Count Node here
                                    new AnyAttackCount(),

                                    //add NormalAttack Pattern Node here
                                    new NormalAttack()
                                })
                            })
                        }),
                        new SequenceNode(new List<Node>
                        {
                            //add In Long Range Node here
                            new InLongRange(),
                            //add Projectile Attack Pattern Node here
                            new ProjectileAttackPattern()
                        })
                    }),
                    new SelectorNode(new List<Node>
                    {
                        new SequenceNode(new List<Node>
                        {
                            //add Any Attack Count Node here
                            new AnyAttackCount(),
                            //add Special Attack 1 Pattern Node here
                            new SpecialAttackPattern1()
                        }),
                        new SequenceNode(new List<Node>
                        {
                            //add Special Attack count Node here
                            new SpecialAttackCount(),
                            //add Special Attack 2 Pattern Node here
                            new SpecialAttackPattern2()
                        })
                    })
                }),
                new TestNode(),
                new NormalAttack()
            }),
            //add Chase Player Node here
            new ChasePlayer()
        });
        */
        Node Root = new SelectorNode(new List<Node>
        {
            new ChasePlayer(Player.transform, Boss.transform)
        });
        return Root;
    }
}
