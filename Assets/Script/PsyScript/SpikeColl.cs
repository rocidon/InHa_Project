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
    // 플레이어 이동
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
    // 점프
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
        // 스파이크 장애물 충돌 시 밀리는 코드
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 충돌 방향 벡터를 계산
                Vector3 collisionDirection = transform.position - collision.transform.position;
                // 충돌 반응을 위해 힘을 적용
                rb.AddForce(collisionDirection.normalized * 300f);
            }


            Debug.Log("충돌 시작!");

        }

        // 점프를 위한 코드(지면에 있을때만 점프 가능)
        if (collision.gameObject.CompareTag("Round"))
        {
            IsJumping = false;
        }

    }

}
