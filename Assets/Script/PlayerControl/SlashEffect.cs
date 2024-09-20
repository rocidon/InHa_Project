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
    public GameObject ParticleObject;
    [SerializeField]
    float ParticleLifeTime;

    void Start()
    {
        ps = ParticleObject.GetComponent<ParticleSystem>();
        ParticleLifeTime = ps.main.startLifetime.constant;
        Debug.Log("particle : " + ParticleLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster") || other.CompareTag("Boss"))
        {
            other.GetComponent<Monster>().TakeDamage(player.normalAttackDamage);
        }
    }

    public void onAtk()
    {
        ParticleObject.GetComponent<BoxCollider>().enabled = true;
        ps.Play();
        StartCoroutine(TurnOffCollsion());
    }

    //void OnParticleTrigger()
    //{
    //    Debug.Log("normal 공격 파티클이 적에게 닿았다.");
    //    ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
    //    normalMonster.TakeDamage(player.normalAttackDamage);
    //    Debug.Log(normalMonster._Health);
        
    //    /* foreach (var v in inside)
    //     {
    //         Debug.Log("Effect Trigger2");
    //     }*/
    //}

    IEnumerator TurnOffCollsion()
    {
        yield return new WaitForSeconds(ParticleLifeTime);
        ParticleObject.GetComponent<BoxCollider>().enabled = false;
    }

}
