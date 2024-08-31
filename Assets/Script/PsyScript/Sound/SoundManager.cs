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
        // ������ ���� ������ ����մϴ�.
        yield return new WaitWhile(() => audioSource.isPlaying);

        // ������ ���� �� ���� ������ ����մϴ�.
        SwapAndPlay();
    }

    private void SwapAndPlay()
    {
        // �� AudioSource�� ��ȯ�Ͽ� ����մϴ�.
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
