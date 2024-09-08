// PlayerMove
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerMove : MonoBehaviour
{
    Rigidbody Rigid;
    public ParticleSystem SnowHit;
    public ParticleSystem StoneSlash;
    public ParticleSystem ElectricSlash;

    float Speed = 10f;       // Player �̵� �ӵ�
    public float JumpPower = 20f;     // Player ���� ����
    bool IsJumping;     // ���� ���� ���� ����
    float GravityScale = 50f;       // �߷� ����
    float MaxHP = 100f;
    public float CurrentHP;
    /* public float _Health;*/
    /* float PlayerAttackDamage = 5f;*/
    float Damage = 20f;
    /*public GameObject Bullet;   
    public Transform FirePos;   */
    public Animator anim;
    public bool IsPlayerDead = false;
    bool DontAttack = false;

    bool IsBanControl = false;
    float delayTime = 0.0f;
    [SerializeField] private float stopTime =1.5f;
    /* bool IsConflict = false;*/

    private float AttackTime;
    /* private float AttackCoolTime = 5.0f;*/
    private bool IsAttackCoolDown = false;
    WaitForSeconds Delay = new WaitForSeconds(1f);

    private AudioSource Player;
    public AudioClip Jump;
    /*public AudioClip Walk;*/
    public AudioClip Hit;
    public AudioClip NormalAttack;
    public AudioClip SpecialAttack;

    public NormalMonster normalmonster;

    void Start()
    {
        CurrentHP = MaxHP;
        Rigid = GetComponent<Rigidbody>();
        IsJumping = false;      // ���� ���� ���� �ʱ�ȭ
        IsPlayerDead = false;
        Player = GetComponent<AudioSource>();
        // normalmonster = GameObject.Find("Enemy").GetComponent<NormalMonster>();
    }

    void Update()
    {
        if (IsBanControl)
        {
            delayTime += Time.deltaTime;
            if (delayTime > stopTime)
            {
                IsBanControl = false;
                delayTime = 0.0f;
            }
            return;
        }

        float xInput = Input.GetAxis("Horizontal");         // GetAxis("Horizontal")�� Player ���� ������
        float xSpeed = xInput * Speed * Time.deltaTime; // Player�� �����̴� ����(xInput)���� Speed�� ���ؼ� �ӵ�(xSpeed)�� �����Ѵ�.


        if (xInput == 0f)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
            /*PlaySound(Walk, Player);*/
        }

        Vector3 newVelocity = new Vector3(xSpeed * 0.8f, 0f, 0f);      // ���� xSpeed�� ���ο� Vector3, newVelocity�� �����Ѵ�.
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
            PlaySound(Jump, Player);
        }

        if (!DontAttack)
        {
            if (Input.GetKeyDown(KeyCode.X) && !IsAttackCoolDown)
            {
                anim.SetTrigger("Attack");
                StoneSlash.Play();
                StartCoroutine(AttackCoolDown());
                PlaySound(NormalAttack, Player);
                IsBanControl = true;

            }

            if (Input.GetKeyDown(KeyCode.C) && !IsAttackCoolDown)
            {
                anim.SetTrigger("Attack");
                ElectricSlash.Play();
                StartCoroutine(AttackCoolDown());
                PlaySound(SpecialAttack, Player);

            }
        }


    }
    private void FixedUpdate()
    {
        Rigid.AddForce(Vector3.down * GravityScale);
        // ���� �� ������ �� �ڿ������� �������� �ϱ� ���� �߷�(gravityScale)�� �����ش�.
    }
    private void OnCollisionEnter(Collision collision)      // Collision Enter ����
    {
        if (collision.gameObject.CompareTag("Enemy") && !IsPlayerDead)
        {
            /*CurrentHP -= EnemyAttackDamage;*/
            TakeDamage(Damage);

            if (CurrentHP <= 0)
            {
                IsPlayerDead = true;
                anim.SetTrigger("Die");
                SnowHit.Play();
                Debug.Log("�׾����ϴ�.");
                PlaySound(Hit, Player);
            }
            else
            {
                anim.SetTrigger("GetHit");
                Debug.Log("���ݹ޾ҽ��ϴ�.");
                OnDamage();
                PlaySound(Hit, Player);
            }
        }

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
            /*Rigid.velocity = Vector3.zero;*/      // HidingFloor������ velocity�� zero
            Speed = 0f;     // Player�� Speed�� 0�� �ȴ�.
            DontAttack = true;      // �� ���� ����
            IsJumping = true;       // ���� ���Ѵ�.

        }
        else if (!collision.gameObject.CompareTag("HidingFloor"))        // Player�� HidingFloor�� ��� ���� �ʴ� ��Ȳ�̶��
        {
            Speed = 10f;        // Speed ���󺹱�
            JumpPower = 20f;            // JumpPower ���󺹱�
            if (IsPlayerDead == true)
            {
                Speed = 0f;
                JumpPower = 0f;
                IsBanControl = true;
            }
            DontAttack = false;     // �� ���� ����

        }
    }
    void OnDamage()
    {
        Rigidbody Rigid = GetComponent<Rigidbody>();
        Rigid.AddForce(transform.forward * -20, ForceMode.Impulse);
        SnowHit.Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Hit : " + this.name);
    }

    private IEnumerator AttackCoolDown()
    {
        IsAttackCoolDown = true;
        yield return Delay;
        IsAttackCoolDown = false;
    }

    public static void PlaySound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = false;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    public void TakeDamage(float damage)        // damage�� ������ ���ݷ��ε� ��� �޾� ���� �� �ִ���?=>
    {
        CurrentHP -= damage;
        Debug.Log("������ ���� �޾ҽ��ϴ�.");
        //StartCoroutine(OnDamage());
        //�����ʿ�
    }
}
