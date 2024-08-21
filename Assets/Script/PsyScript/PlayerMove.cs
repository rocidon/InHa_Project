using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction = Vector3.zero;
    private bool IsJumping;
    public float jumpForce = 5f;
    public float speed = 3f;
    public int coin;
    public int spike;
    public int blade;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsJumping = false;
        coin = 0;
        spike = 0;
        blade = 0;
    }


    void Update()
    {
        Move();
        Jump();
        Debug.Log(coin);
        Debug.Log(spike);
        Debug.Log(blade);
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
        // 점프를 위한 코드(지면에 있을때만 점프 가능)
        if (collision.gameObject.CompareTag("Round"))
        {
            IsJumping = false;
        }

    }


}
