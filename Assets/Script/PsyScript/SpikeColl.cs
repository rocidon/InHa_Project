using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction = Vector3.zero;
    private bool IsJumping;
    public float jumpForce = 5f;
    public float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsJumping = false;
    }


    void Update()
    {
        Move();
        Jump();
    }
    // �÷��̾� �̵�
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        if (h < 0)
        {
            direction = Vector3.right;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (h > 0)
        {
            direction = Vector3.left;
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }

        transform.Translate((new Vector3(h, 0) * speed) * Time.deltaTime);



    }
    // ����
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJumping)
            {
                IsJumping = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        // ������ũ ��ֹ� �浹 �� �и��� �ڵ�
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // �浹 ���� ���͸� ���
                Vector3 collisionDirection = transform.position - collision.transform.position;
                // �浹 ������ ���� ���� ����
                rb.AddForce(collisionDirection.normalized * 300f);
            }


            Debug.Log("�浹 ����!");

        }

        // ������ ���� �ڵ�(���鿡 �������� ���� ����)
        if (collision.gameObject.CompareTag("Round"))
        {
            IsJumping = false;
        }

    }

}
