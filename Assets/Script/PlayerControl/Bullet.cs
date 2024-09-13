// Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bullet : MonoBehaviour
{
    public ParticleSystem GreenHit;
    GameObject player;
    public float damage = 20.0f;        // �Ѿ� ������, ���Ϳ� �浹 �� �������� �� �� �ְ�
    public float force = 1.0f;          // �Ѿ��� ���ư��� ��
    private Rigidbody Rigid;
    private BoxCollider Collider;
    bool IsShoot = true;


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
        Destroy(gameObject, 3f);        // 3�� �� �Ѿ� �������� ���������
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
        //180 - player.y���� 
        //90 -> 90   -90 -> 270

        if(IsShoot) transform.Translate(new Vector3(0f, -1f, 0f) * 15f * Time.deltaTime);     // �Ѿ��� �̵��ϴ� ����(x��)�� �ӵ�

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("ȭ��� ���� ����");
            GreenHit.Play();
            IsShoot = false;
        }
    }



    /* private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.CompareTag("Enemy"))
         {
             Debug.Log("������ ȭ���� �������ϴ�.");
             GreenHit.Play();
             Destroy(gameObject);
         }
     }*/
}