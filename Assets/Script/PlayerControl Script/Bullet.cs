// Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20.0f;        // �Ѿ� ������, ���Ϳ� �浹 �� �������� �� �� �ְ�

    public float force = 1.0f;          // �Ѿ��� ���ư��� ��

    private Rigidbody Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);        // 3�� �� �Ѿ� �������� ���������
    }

    void Update()
    {
        /*Rigid.AddForce(transform.forward * force);*/
        transform.Translate(new Vector3(0.05f, 0, 0));      // �Ѿ��� �̵��ϴ� ����(x��)�� �ӵ�
    }
}
