// PlayerMove
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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

    float Speed = 7f;       // Player �̵� �ӵ�
    public float JumpPower = 18f;     // Player ���� ����
    bool IsJumping;     // ���� ���� ���� ����
    float GravityScale = 50f;       // �߷� ����
    public float MaxHP = 100f;      
    public float CurrentHP;
    /* public float _Health;*/
    /* float PlayerAttackDamage = 5f;*/
    float Damage = 20f;
    /*public GameObject Bullet;   
    public Transform FirePos;   */
    public Animator anim;
    public bool IsPlayerDead = false;
    bool DontAttack = false;

    public bool IsBanControl = false;
    float delayTime = 0.0f;             // normal ���� delayTime

    public float stopTime = 1.5f;
    /*[SerializeField] private*/
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

    public NormalMonster normalMonsterAttack;
    GameObject nearObject;

    int normalWeaponCount = 0;
    int specialWeaponCount = 0;

    public float normalAttackDamage = 10.0f;          // normal ���� ���ݷ�
    public float specialAttackDamage = 15.0f;         // special ���� ���ݷ�
    

    void Start()
    {
        CurrentHP = MaxHP;
        Rigid = GetComponent<Rigidbody>();
        IsJumping = false;      // ���� ���� ���� �ʱ�ȭ
        IsPlayerDead = false;
        Player = GetComponent<AudioSource>();
        /*normalMonsterAttack = GameObject.Find("NormalMonster").GetComponent<NormalMonster>(); //*/
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

        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)          // ���� ���� �ְ� ZŰ�� ������
        {
            Rigid.AddForce(transform.up * JumpPower, ForceMode.Impulse);        // transform.up �������� JumpPower��ŭ �����Ѵ�.
            IsJumping = true;       // Player�� �����Ѵ�.
            anim.SetTrigger("Jump");
            PlaySound(Jump, Player);
        }

        if (!DontAttack)
        {
            if (Input.GetKeyDown(KeyCode.C) && !IsAttackCoolDown && normalWeaponCount == 1)
            {
                anim.SetTrigger("Attack");
                StoneSlash.Play();
                StartCoroutine(AttackCoolDown());
                PlaySound(NormalAttack, Player);
                IsBanControl = true;

            }

            if (Input.GetKeyDown(KeyCode.X) && !IsAttackCoolDown && specialWeaponCount == 1)
            {
                anim.SetTrigger("Attack");
                ElectricSlash.Play();
                StartCoroutine(AttackCoolDown());
                PlaySound(SpecialAttack, Player);

            }
        }

        if (CurrentHP <= 0)     // �÷��̾�HP�� enemy�� �ε����� �� �������
        {
            IsPlayerDead = true;
            CurrentHP = 0;
            anim.SetTrigger("Die");
            SnowHit.Play();
            Debug.Log(CurrentHP);
            Debug.Log("�׾����ϴ�.");
            PlaySound(Hit, Player);
        }

    }
    private void FixedUpdate()
    {
        Rigid.AddForce(Vector3.down * GravityScale);
        // ���� �� ������ �� �ڿ������� �������� �ϱ� ���� �߷�(gravityScale)�� �����ش�.
    }
    private void OnCollisionEnter(Collision collision)      // Collision Enter ����
    {
        if (collision.gameObject.CompareTag("Monster") && !IsPlayerDead)
        {
            /*CurrentHP -= EnemyAttackDamage;*/
            /*TakeDamage(20);*/

            if (CurrentHP <= 0)     
            {
                IsPlayerDead = true;
                CurrentHP = 0;
                anim.SetTrigger("Die");
                SnowHit.Play();
                Debug.Log("�׾����ϴ�.");
                PlaySound(Hit, Player);
            }
            else
            {
                anim.SetTrigger("GetHit");
                Debug.Log("���ݹ޾ҽ��ϴ�.");
                /*OnDamage();*/
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
            Speed = 7f;        // Speed ���󺹱�
            JumpPower = 18f;            // JumpPower ���󺹱�
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

    public void TakeDamage(float MonsterDamage)       // damage�� ������ ���ݷ��ε� ��� �޾� ���� �� �ִ���?
    {                                           /* ���� comment : ���Ϳ��� �������ָ� �ذ��, TakeDamage�� �߻��ϸ�
                                                 * onDamage�� �� �Լ� ������ ȣ�����ָ� ������ TakeDamage�� �ǰݵ����� ó��
                                                 * onDamage���� �ǰ� �� �з����� �̺�Ʈ ó�� */
        //normalMonsterDamage = normalMonsterAttack._Atk;
        CurrentHP -= MonsterDamage;
        Debug.Log("MonsterDamage : " + MonsterDamage);
        OnDamage();
        //StartCoroutine(OnDamage());
        //Enermy
    }
    void OnTriggerStay(Collider other)              // normal���� �Ծ��� �� ���� �����ϵ���
    {
        if (other.tag == "normalWeapon")
        {
            nearObject = other.gameObject;
            Debug.Log("Normal �� ȹ��");
            nearObject.SetActive(false);
            normalWeaponCount++;
        }

        if (other.tag == "specialWeapon")           // speical���� �Ծ��� �� ���� �����ϵ���
        {
            nearObject = other.gameObject;
            Debug.Log("Special �� ȹ��");
            nearObject.SetActive(false);
            specialWeaponCount++;
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "normalWeapon")
        {
            nearObject = null;
        }
    }*/
}
