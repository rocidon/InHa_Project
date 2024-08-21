// PlayerMove
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    Rigidbody Rigid;
    
    static float Speed = 10f;       // Player 이동 속도
    public float JumpPower = 20f;     // Player 점프 높이
    bool IsJumping;     // 점프 유무 변수 선언
    float gravityScale = 50f;       // 중력 변수
    public GameObject Bullet;       // Player에 있는 Bullet 
    public Transform FirePos;       // Player에 있는 FirePos.

    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        IsJumping = false;      // 점프 유무 변수 초기화
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");         // GetAxis("Horizontal")로 Player 방향 움직임
        float xSpeed = xInput * Speed * Time.deltaTime;             // Player가 움직이는 방향(xInput)으로 Speed를 곱해서 속도(xSpeed)를 정의한다.

        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);      // 위의 xSpeed를 새로운 Vector3, newVelocity로 정의한다.
        transform.position += newVelocity;      // transform.position에 newVelocity를 더해 Player가 움직일 수 있도록 한다.

        if (xInput > 0)     // x축이 양수인 방향으로 움직일 때
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));     // 그 방향을 바라보고(방향이 바뀌지 않음)
        }
        else if (xInput < 0)    // x축이 음수인 방향으로 움직일 때
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));       // 움직인 방향으로 Player가 회전한다.(y축으로 180도)
        }

        if (Input.GetKeyDown(KeyCode.Z) && !IsJumping)          // 지면 위에 있고 Z키를 누르면
        {
            Rigid.AddForce(transform.up * JumpPower, ForceMode.Impulse);        // transform.up 방향으로 JumpPower만큼 점프한다.
            IsJumping = true;       // Player가 점프한다.
        }
    }
    private void FixedUpdate()
    {
        Rigid.AddForce(Vector3.down * gravityScale);
        // 점프 후 내려올 때 자연스럽게 내려오게 하기 위해 중력(gravityScale)을 곱해준다.
    }
    void OnCollisionEnter(Collision collision)      // Collision Enter 판정
    {
        if (collision.gameObject.CompareTag("Floor"))       // Player가 Floor를 밟고 있다면
        {
            IsJumping = false;      // 언제든지 점프키를 누르면 점프할 수 있다.
        }
    }
    void OnCollisionStay(Collision collision)       // Collision Stay 판정
    {
        if (collision.gameObject.CompareTag("HidingFloor"))     // Player가 HidingFloor를 밟고 있다면
        {
            JumpPower = 0f;     // HidingFloor에서는 점프 불가
            Debug.Log("HidingPosition입니다.");
            Rigid.velocity = Vector3.zero;      // HidingFloor에서는 velocity가 zero
            Speed = 0f;     // Player의 Speed가 0이 된다.
            
        }
        else if(!collision.gameObject.CompareTag("HidingFloor"))        // Player가 HidingFloor를 밟고 있지 않는 상황이라면
        {
            Speed = 10f;        // Speed 원상복구
            JumpPower = 20f;            // JumpPower 원상복구
        }
    }
}

