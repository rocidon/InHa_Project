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

    float Speed = 7f;       // Player 이동 속도
    public float JumpPower = 18f;     // Player 점프 높이
    bool IsJumping;     // 점프 유무 변수 선언
    float GravityScale = 50f;       // 중력 변수
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
    float delayTime = 0.0f;             // normal 공격 delayTime

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

    public float normalAttackDamage = 10.0f;          // normal 무기 공격력
    public float specialAttackDamage = 15.0f;         // special 무기 공격력
    

    void Start()
    {
        CurrentHP = MaxHP;
        Rigid = GetComponent<Rigidbody>();
        IsJumping = false;      // 점프 유무 변수 초기화
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

        float xInput = Input.GetAxis("Horizontal");         // GetAxis("Horizontal")로 Player 방향 움직임
        float xSpeed = xInput * Speed * Time.deltaTime; // Player가 움직이는 방향(xInput)으로 Speed를 곱해서 속도(xSpeed)를 정의한다.


        if (xInput == 0f)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
            /*PlaySound(Walk, Player);*/
        }

        Vector3 newVelocity = new Vector3(xSpeed * 0.8f, 0f, 0f);      // 위의 xSpeed를 새로운 Vector3, newVelocity로 정의한다.
        transform.position += newVelocity;      // transform.position에 newVelocity를 더해 Player가 움직일 수 있도록 한다.

        if (xInput > 0)     // x축이 양수인 방향으로 움직일 때
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));     // 그 방향을 바라보고(방향이 바뀌지 않음)

        }
        else if (xInput < 0)    // x축이 음수인 방향으로 움직일 때
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));       // 움직인 방향으로 Player가 회전한다.(y축으로 180도)
        }

        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)          // 지면 위에 있고 Z키를 누르면
        {
            Rigid.AddForce(transform.up * JumpPower, ForceMode.Impulse);        // transform.up 방향으로 JumpPower만큼 점프한다.
            IsJumping = true;       // Player가 점프한다.
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

        if (CurrentHP <= 0)     // 플레이어HP가 enemy와 부딪히는 거 상관없이
        {
            IsPlayerDead = true;
            CurrentHP = 0;
            anim.SetTrigger("Die");
            SnowHit.Play();
            Debug.Log(CurrentHP);
            Debug.Log("죽었습니다.");
            PlaySound(Hit, Player);
        }

    }
    private void FixedUpdate()
    {
        Rigid.AddForce(Vector3.down * GravityScale);
        // 점프 후 내려올 때 자연스럽게 내려오게 하기 위해 중력(gravityScale)을 곱해준다.
    }
    private void OnCollisionEnter(Collision collision)      // Collision Enter 판정
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
                Debug.Log("죽었습니다.");
                PlaySound(Hit, Player);
            }
            else
            {
                anim.SetTrigger("GetHit");
                Debug.Log("공격받았습니다.");
                /*OnDamage();*/
                PlaySound(Hit, Player);
            }
        }

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
            /*Rigid.velocity = Vector3.zero;*/      // HidingFloor에서는 velocity가 zero
            Speed = 0f;     // Player의 Speed가 0이 된다.
            DontAttack = true;      // 검 공격 못함
            IsJumping = true;       // 점프 못한다.

        }
        else if (!collision.gameObject.CompareTag("HidingFloor"))        // Player가 HidingFloor를 밟고 있지 않는 상황이라면
        {
            Speed = 7f;        // Speed 원상복구
            JumpPower = 18f;            // JumpPower 원상복구
            if (IsPlayerDead == true)
            {
                Speed = 0f;
                JumpPower = 0f;
                IsBanControl = true;
            }
            DontAttack = false;     // 검 공격 가능

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

    public void TakeDamage(float MonsterDamage)       // damage는 몬스터의 공격력인데 어떻게 받아 들일 수 있는지?
    {                                           /* 덕상 comment : 몬스터에서 전달해주면 해결됨, TakeDamage가 발생하면
                                                 * onDamage도 이 함수 내에서 호출해주면 가능함 TakeDamage로 피격데미지 처리
                                                 * onDamage에서 피격 시 밀려나는 이벤트 처리 */
        //normalMonsterDamage = normalMonsterAttack._Atk;
        CurrentHP -= MonsterDamage;
        Debug.Log("MonsterDamage : " + MonsterDamage);
        OnDamage();
        //StartCoroutine(OnDamage());
        //Enermy
    }
    void OnTriggerStay(Collider other)              // normal무기 먹었을 때 공격 가능하도록
    {
        if (other.tag == "normalWeapon")
        {
            nearObject = other.gameObject;
            Debug.Log("Normal 검 획득");
            nearObject.SetActive(false);
            normalWeaponCount++;
        }

        if (other.tag == "specialWeapon")           // speical무기 먹었을 때 공격 가능하도록
        {
            nearObject = other.gameObject;
            Debug.Log("Special 검 획득");
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
