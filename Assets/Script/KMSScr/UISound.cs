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
            // ����� �ҽ��� ������ �� ��ü�� �ı����� �ʵ��� ����
            DontDestroyOnLoad(myAudioSource);
        }
        else
        {
            // ����� �ҽ��� ������ �� ��ü�� �ı�
            Destroy(myAudioSource);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
