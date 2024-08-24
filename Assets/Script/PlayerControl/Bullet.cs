// Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bullet : MonoBehaviour
{
    GameObject player;

    public float damage = 20.0f;        // 총알 데미지, 몬스터와 충돌 시 데미지가 들어갈 수 있게

    public float force = 1.0f;          // 총알이 날아가는 힘

    private Rigidbody Rigid;

    private void Start()
    {
        player = GameObject.FindWithTag("RogueHooded");
        Rigid = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f - player.transform.eulerAngles.y));
        Destroy(gameObject, 3f);        // 3초 뒤 총알 프리팹이 사라지도록
    }

    void Update()
    {

        /*Rigid.AddForce(transform.forward * force);*/
            //180 - player.y방향 
        //90 -> 90   -90 -> 270
            
            transform.Translate(new Vector3(0f, -0.05f, 0f));      // 총알이 이동하는 방향(x축)과 속도
    }
}
