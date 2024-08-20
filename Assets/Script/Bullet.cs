// Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20.0f;        // 총알 데미지, 몬스터와 충돌 시 데미지가 들어갈 수 있게

    public float force = 1.0f;          // 총알이 날아가는 힘

    private Rigidbody Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);        // 3초 뒤 총알 프리팹이 사라지도록
    }

    void Update()
    {
        /*Rigid.AddForce(transform.forward * force);*/
        transform.Translate(new Vector3(0.05f, 0, 0));      // 총알이 이동하는 방향(x축)과 속도
    }
}
