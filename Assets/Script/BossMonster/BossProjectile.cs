using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    //참고 사이트 : 
    // https://ardmos.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-ResourcesLoad-%EC%8A%A4%ED%81%AC%EB%A6%BD%ED%8A%B8%EC%83%81%EC%97%90%EC%84%9C-%EC%9C%A0%EB%8B%88%ED%8B%B0-Resources-%ED%8F%B4%EB%8D%94%EC%97%90-%EC%9E%88%EB%8A%94-%ED%94%84%EB%A6%AC%ED%8C%B9-instantiate-%ED%95%98%EA%B8%B0
    //골렘 에셋 내에 있는 ThrowingRock에 구 콜리전이랑 이 스크립트 달아서 작성함
    [SerializeField]
    GameObject Target;
    [SerializeField]
    float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 10.0f;
        Target = GameObject.FindWithTag("Player");
        if (Target.CompareTag("Player"))
        {
            transform.LookAt(Target.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Play Parent");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
        if(!other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
