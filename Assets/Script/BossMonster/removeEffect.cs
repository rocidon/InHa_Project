using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeEffect : MonoBehaviour
{
    float Duration;
    void Start()
    {
        Duration = GetComponent<ParticleSystem>().main.duration;
        //Debug.Log("���Ÿ� ��ƼŬ �ð� : " + Duration);
        StartCoroutine(ChkTime());
    }

    IEnumerator ChkTime()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }
}
