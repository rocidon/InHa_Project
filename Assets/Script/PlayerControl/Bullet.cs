// Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bullet : MonoBehaviour
{
    public ParticleSystem GreenHit;
    GameObject player;
    public float damage = 20.0f;        // 총알 데미지, 몬스터와 충돌 시 데미지가 들어갈 수 있게
    public float force = 1.0f;          // 총알이 날아가는 힘
    private Rigidbody Rigid;
    bool ShootStop = false;
    /*Renderer renderer;
    public GameObject target;*/

    /*private*/
    void Start()
    {
        player = GameObject.FindWithTag("RogueHooded");
        Rigid = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f - player.transform.eulerAngles.y));
        Destroy(gameObject, 3f);        // 3초 뒤 총알 프리팹이 사라지도록
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
        if (!ShootStop)
        {
            transform.Translate(new Vector3(0f, -0.15f, 0f));     // 총알이 이동하는 방향(x축)과 속도
        }
    }

    void OnCollisionEnter(Collision collision)      // Collision Enter 판정
    {
        ShootStop = true;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("화살이 적을 맞췄습니다.");
            GreenHit.Play();
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject, 3f);
            /*StartCoroutine("FadeOut");*/
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