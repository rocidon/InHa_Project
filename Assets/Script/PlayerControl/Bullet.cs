// Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bullet : MonoBehaviour
{
    public ParticleSystem GreenHit;
    GameObject player;
    public float shootDamage = 20.0f;        // 총알 데미지, 몬스터와 충돌 시 데미지가 들어갈 수 있게
    public float force = 1.0f;          // 총알이 날아가는 힘
    private Rigidbody Rigid;
    private BoxCollider Collider;
    bool IsShoot = true;

    public NormalMonster normalMonster;
    public BossMonster1 bossMonster;


    /*Renderer renderer;
    public GameObject target;*/

    /*private*/
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Rigid = GetComponent<Rigidbody>();
        Collider = GetComponent<BoxCollider>();
        Rigid.isKinematic = true;
        Collider.isTrigger = true;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f - player.transform.eulerAngles.y));
    }
    void Start()
    {
        Destroy(gameObject, 3f);        // 3초 뒤 총알 프리팹이 사라지도록
        bossMonster = GameObject.Find("Boss").GetComponent<BossMonster1>();
        /*renderer = target.GetComponent<Renderer>();*/
        /* Application.targetFrameRate = 60;
         Shoot(new Vector3(0, 0, 100));*/
    }

    /*  IEnumerator FadeOut()
      {
          Color c = renderer.material.color;
          c.a = 0;
          renderer.material.color = c;
          yield return new WaitForSeconds(0.01f);
      }*/

    void Update()
    {
        /*Rigid.AddForce(transform.forward * force);*/
        //180 - player.y방향 
        //90 -> 90   -90 -> 270

        if(IsShoot) transform.Translate(new Vector3(0f, -1f, 0f) * 15f * Time.deltaTime);     // 총알이 이동하는 방향(x축)과 속도

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boss") || other.CompareTag("Monster"))        // 활로 보스를 맞출 때(활은 Boss 전에서 밖에 쓰지 못한다.)
        {   
            Debug.Log("화살로 적을 맞춤");
            GreenHit.Play();
            //bossMonster._Health -= shootDamage;     // boss 몬스터 hp가 shootDamage 만큼 깎인다.
            //Debug.Log(bossMonster._Health);
            other.GetComponent<Monster>().TakeDamage(shootDamage);
            Destroy(gameObject, 0.3f);
            IsShoot = false;
        }
    }



    /* private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.CompareTag("Enemy"))
         {
             Debug.Log("적에게 화살이 꽂혔습니다.");
             GreenHit.Play();
             Destroy(gameObject);
         }
     }*/
}