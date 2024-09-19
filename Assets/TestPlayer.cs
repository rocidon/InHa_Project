using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class TestPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    float dist;
    float Speed;
    float Vx;
    float Vy;
    float Theta60;
    float Duration;
    // Update is called once per frame
    private void Awake()
    {
        Duration = 2.0f;
        Theta60 = 60.0f * 3.141592f / 180.0f;
        dist = 5.0f;
        Speed = dist / (Mathf.Sin(2*60.0f * Mathf.Deg2Rad)/9.8f);
        Vx = Mathf.Sqrt(Speed) * Mathf.Cos(60.0f*Mathf.Deg2Rad);
        Vy = Mathf.Sqrt(Speed) * Mathf.Sin(60.0f*Mathf.Deg2Rad);
        Duration = dist / Vx;
        //transform.rotation = Quaternion.LookRotation(targetPoint.position - startPoint.position);
    }

    private void Start()
    {
        StartCoroutine(A());
    }
    void Update()
    {

    }

    IEnumerator A()
    {
        float elapse_time = 0;
        while (elapse_time < Duration)
        {
            transform.Translate(Vx * Time.deltaTime, (Vy - (9.8f * elapse_time)) * Time.deltaTime,0);
            elapse_time += Time.deltaTime;
            yield return null;
        }
    }
}
