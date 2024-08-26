// Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bullet : MonoBehaviour
{
    GameObject player;

    public float damage = 20.0f;        // �Ѿ� ������, ���Ϳ� �浹 �� �������� �� �� �ְ�

    public float force = 1.0f;          // �Ѿ��� ���ư��� ��

    private Rigidbody Rigid;

    private void Start()
    {
        player = GameObject.FindWithTag("RogueHooded");
        Rigid = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f - player.transform.eulerAngles.y));
        Destroy(gameObject, 3f);        // 3�� �� �Ѿ� �������� ���������
    }

    void Update()
    {

        /*Rigid.AddForce(transform.forward * force);*/
            //180 - player.y���� 
        //90 -> 90   -90 -> 270
            
            transform.Translate(new Vector3(0f, -0.05f, 0f));      // �Ѿ��� �̵��ϴ� ����(x��)�� �ӵ�
    }
}
