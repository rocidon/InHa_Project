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
    
    static float Speed = 10f;       // Player �̵� �ӵ�
    public float JumpPower = 20f;     // Player ���� ����
    bool IsJumping;     // ���� ���� ���� ����
    float gravityScale = 50f;       // �߷� ����
    public GameObject Bullet;       // Player�� �ִ� Bullet 
    public Transform FirePos;       // Player�� �ִ� FirePos.

    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        IsJumping = false;      // ���� ���� ���� �ʱ�ȭ
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");         // GetAxis("Horizontal")�� Player ���� ������
        float xSpeed = xInput * Speed * Time.deltaTime;             // Player�� �����̴� ����(xInput)���� Speed�� ���ؼ� �ӵ�(xSpeed)�� �����Ѵ�.

        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);      // ���� xSpeed�� ���ο� Vector3, newVelocity�� �����Ѵ�.
        transform.position += newVelocity;      // transform.position�� newVelocity�� ���� Player�� ������ �� �ֵ��� �Ѵ�.

        if (xInput > 0)     // x���� ����� �������� ������ ��
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));     // �� ������ �ٶ󺸰�(������ �ٲ��� ����)
        }
        else if (xInput < 0)    // x���� ������ �������� ������ ��
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));       // ������ �������� Player�� ȸ���Ѵ�.(y������ 180��)
        }

        if (Input.GetKeyDown(KeyCode.Z) && !IsJumping)          // ���� ���� �ְ� ZŰ�� ������
        {
            Rigid.AddForce(transform.up * JumpPower, ForceMode.Impulse);        // transform.up �������� JumpPower��ŭ �����Ѵ�.
            IsJumping = true;       // Player�� �����Ѵ�.
        }
    }
    private void FixedUpdate()
    {
        Rigid.AddForce(Vector3.down * gravityScale);
        // ���� �� ������ �� �ڿ������� �������� �ϱ� ���� �߷�(gravityScale)�� �����ش�.
    }
    void OnCollisionEnter(Collision collision)      // Collision Enter ����
    {
        if (collision.gameObject.CompareTag("Floor"))       // Player�� Floor�� ��� �ִٸ�
        {
            IsJumping = false;      // �������� ����Ű�� ������ ������ �� �ִ�.
        }
    }
    void OnCollisionStay(Collision collision)       // Collision Stay ����
    {
        if (collision.gameObject.CompareTag("HidingFloor"))     // Player�� HidingFloor�� ��� �ִٸ�
        {
            JumpPower = 0f;     // HidingFloor������ ���� �Ұ�
            Debug.Log("HidingPosition�Դϴ�.");
            Rigid.velocity = Vector3.zero;      // HidingFloor������ velocity�� zero
            Speed = 0f;     // Player�� Speed�� 0�� �ȴ�.
            
        }
        else if(!collision.gameObject.CompareTag("HidingFloor"))        // Player�� HidingFloor�� ��� ���� �ʴ� ��Ȳ�̶��
        {
            Speed = 10f;        // Speed ���󺹱�
            JumpPower = 20f;            // JumpPower ���󺹱�
        }
    }
}

