using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

    public NormalMonster normalMonster;
    public PlayerMove player;

    void Start()
    {
        normalMonster = GameObject.Find("NormalMonster").GetComponent<NormalMonster>();
        player = GameObject.Find("ImprovedPlayerPrefab").GetComponent<PlayerMove>();
    }

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        Debug.Log("normal 공격 파티클이 적에게 닿았다.");
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        normalMonster.TakeDamage(player.normalAttackDamage);
        Debug.Log(normalMonster._Health);
        
        /* foreach (var v in inside)
         {
             Debug.Log("Effect Trigger2");
         }*/
    }
}
