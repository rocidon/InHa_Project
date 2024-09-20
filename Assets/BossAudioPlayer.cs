using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudioPlayer : MonoBehaviour
{

    private AudioSource Boss;
    public AudioClip Jump;
    /*public AudioClip Walk;*/
    public AudioClip Hit;
    public AudioClip NormalAttack;
    public AudioClip SpecialAttack;

    // Start is called before the first frame update
    void Start()
    {
        Boss = GetComponent<AudioSource>();
        PlaySound(Jump, Boss);        // 배경음악 실행
    }

    // Update is called once per frame
    public static void PlaySound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = false;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}
