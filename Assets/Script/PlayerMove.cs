using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    Rigidbody Rigid;
    
    static float Speed = 10f;
    public float JumpPower = 20f;     // 점프 높이 변수 선언
    bool IsJumping;     // 점프 유무 변수 선언
    float gravityScale = 50f;       // 중력 작용
    public GameObject Bullet;
    public Transform FirePos;
    
   /* float zInput = 0;*/
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        IsJumping = false;      // 점프 유무 변수 초기화
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        float xSpeed = xInput * Speed * Time.deltaTime;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);
        transform.position += newVelocity;

        if (xInput > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
        else if (xInput < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }

        //if (Input.GetKey(KeyCode.RightArrow))
        //{


        //    transform.Translate(new Vector3(Speed, 0, 0));

        //}


        //if (Input.GetKey(KeyCode.LeftArrow))
        //{

        //    transform.Translate(new Vector3(-Speed, 0, 0));

        //}

        if (Input.GetKeyDown(KeyCode.UpArrow) && !IsJumping)
        {
            Rigid.AddForce(transform.up * JumpPower, ForceMode.Impulse);
            IsJumping = true;
        }
    }
    private void FixedUpdate()
    {
        Rigid.AddForce(Vector3.down * gravityScale);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            IsJumping = false;
        }
    }
}
