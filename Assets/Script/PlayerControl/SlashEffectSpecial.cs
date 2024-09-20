using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffectSpecial : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

    public NormalMonster normalMonster;
    public BossMonster1 bossMonster;
    public PlayerMove player;
    public Monster monster;

    void Start()
    {
        normalMonster = GameObject.Find("NormalMonster").GetComponent<NormalMonster>();
        player = GameObject.Find("ImprovedPlayerPrefab").GetComponent<PlayerMove>();
        bossMonster = GameObject.Find("Boss").GetComponent<BossMonster1>();
    }

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        Debug.Log("Special 공격 파티클이 적에게 닿았다.");
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        normalMonster.TakeDamage(player.specialAttackDamage);
        bossMonster.TakeDamage(player.specialAttackDamage);
        Debug.Log(normalMonster._Health);
        //monster.TakeDamage();
        /* foreach (var v in inside)
         {
             Debug.Log("Effect Trigger2");
         }*/
    }

}
