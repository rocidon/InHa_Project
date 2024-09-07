using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePsy : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction = Vector3.zero;
    private bool IsJumping;
    public float jumpForce = 5f;
    public float speed = 3f;
    public int coin;
    public int spike;
    public int blade;
    public int itembox;
    public int potal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsJumping = false;
        coin = 0;
        spike = 0;
        blade = 0;
        itembox = 0;
        potal = 0;
    }


    void Update()
    {
        Move();
        Jump();
        //Debug.Log(coin);
        //Debug.Log(spike);
        //Debug.Log(blade);
        //Debug.Log(itembox);
        //Debug.Log(potal);

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
        // ������ ���� �ڵ�(���鿡 �������� ���� ����)
        if (collision.gameObject.CompareTag("Round"))
        {
            IsJumping = false;
        }

    }


}
