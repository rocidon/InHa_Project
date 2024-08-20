using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // ������ũ ��ֹ� �浹 �� �и��� �ڵ�
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().spike++;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // �浹 ���� ���͸� ���
                Vector3 collisionDirection = transform.position - collision.transform.position;
                // �浹 ������ ���� ���� ����
                rb.AddForce(collisionDirection.normalized * -200f);
            }


            Debug.Log("�浹 ����!");

        }
    }
}
