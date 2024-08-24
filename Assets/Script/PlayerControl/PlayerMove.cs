// PlayerMove
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    Rigidbody Rigid;
    
    static float Speed = 10f;       // Player �̵� �ӵ�
    public float JumpPower = 20f;     // Player ���� ����
    bool IsJumping;     // ���� ���� ���� ����
    float GravityScale = 50f;       // �߷� ����
    float MaxHP = 1000f;
    float CurrentHP;
    float PlayerAttackDamage = 5f;
    float EnemyAttackDamage = 20f;
    public GameObject Bullet;       // Player�� �ִ� Bullet 
    public Transform FirePos;       // Player�� �ִ� FirePos.
    public Animator anim;
    bool IsPlayerDead = false;

    void Start()
    {
        CurrentHP = MaxHP;
        Rigid = GetComponent<Rigidbody>();
        IsJumping = false;      // ���� ���� ���� �ʱ�ȭ
        IsPlayerDead = false;
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");         // GetAxis("Horizontal")�� Player ���� ������
        float xSpeed = xInput * Speed * Time.deltaTime; // Player�� �����̴� ����(xInput)���� Speed�� ���ؼ� �ӵ�(xSpeed)�� �����Ѵ�.

        if (xInput == 0f)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
        }

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
            anim.SetTrigger("Jump");
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Attack");
        }

    }
    private void FixedUpdate()
    {
        Rigid.AddForce(Vector3.down * GravityScale);
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
            /*Rigid.velocity = Vector3.zero; */     // HidingFloor������ velocity�� zero
            Speed = 0f;     // Player�� Speed�� 0�� �ȴ�.
            
        }
        else if(!collision.gameObject.CompareTag("HidingFloor"))        // Player�� HidingFloor�� ��� ���� �ʴ� ��Ȳ�̶��
        {
            Speed = 10f;        // Speed ���󺹱�
            JumpPower = 20f;            // JumpPower ���󺹱�
        }


        if (collision.gameObject.CompareTag("Enemy") && !IsPlayerDead)
        {
           
            CurrentHP -= EnemyAttackDamage;
        
            if(CurrentHP <= 0)
            {
                IsPlayerDead =true;
                anim.SetTrigger("Die");         // �ִϸ��̼� �� ����
                anim.SetTrigger("Dead");
                if (IsPlayerDead)
                {
                    Speed = 0f;
                    JumpPower = 0f;
                }
                Debug.Log("�׾����ϴ�.");
            }
            else
            {
                anim.SetTrigger("GetHit");
                Debug.Log("���ݹ޾ҽ��ϴ�.");
            }
        }
    }

  
}

