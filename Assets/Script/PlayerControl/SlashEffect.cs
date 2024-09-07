using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }
    
    private void OnParticleTrigger()
    {
        Debug.Log("���� ��ƼŬ�� ������ ��Ҵ�.");
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        
        /* foreach (var v in inside)
         {
             Debug.Log("Effect Trigger2");
         }*/
    }
}
