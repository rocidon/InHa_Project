using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource StageAudio1;
    public AudioSource StageAudio2;
    public AudioClip Dungeon1;
    public AudioClip Dungeon2;


    void Start()
    {
        StageAudio1.clip = Dungeon1;
        StageAudio2.clip = Dungeon2;

        StageAudio1.Play();
        StartCoroutine(WaitForMusicToEnd(StageAudio1));
    }

    private System.Collections.IEnumerator WaitForMusicToEnd(AudioSource audioSource)
    {
        // 음악이 끝날 때까지 대기합니다.
        yield return new WaitWhile(() => audioSource.isPlaying);

        // 음악이 끝난 후 다음 음악을 재생합니다.
        SwapAndPlay();
    }

    private void SwapAndPlay()
    {
        // 두 AudioSource를 교환하여 재생합니다.
        if (StageAudio1.isPlaying)
        {
            StageAudio1.Stop();
            StageAudio2.Play();
            StartCoroutine(WaitForMusicToEnd(StageAudio2));
        }
        else
        {
            StageAudio2.Stop();
            StageAudio1.Play();
            StartCoroutine(WaitForMusicToEnd(StageAudio2));
        }
    }
}
