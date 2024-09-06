using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{

    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        if (myAudioSource != null)
        {
            // 오디오 소스가 있으면 이 객체를 파괴하지 않도록 설정
            DontDestroyOnLoad(myAudioSource);
        }
        else
        {
            // 오디오 소스가 없으면 이 객체를 파괴
            Destroy(myAudioSource);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
