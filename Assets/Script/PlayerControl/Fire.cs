// Fire
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] Animator anime;
    public GameObject Bullet;
    public Transform FirePos;
    public Animator anim;
    bool DontShoot = false;
    private float ShootTime;
    /* private float ShootCoolTime = 5.0f;*/
    private bool IsShootCoolDown = false;
    WaitForSeconds Delay = new WaitForSeconds(1f);

    public PlayerMove player;
    GameObject nearObject;
    int crossBowCount = 0;

    private AudioSource Crossbow;
    public AudioClip CrossbowShoot;


    void Start()
    {
        Crossbow = GetComponent<AudioSource>();
        player = GameObject.Find("ImprovedPlayerPrefab").GetComponent<PlayerMove>();
    }
    void Update()
    {
       

        if (!DontShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !IsShootCoolDown && crossBowCount == 1)
            {
              

                Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);

                anim.SetTrigger("Shoot");
                ShootTime = 0;
                StartCoroutine(ShootCoolDown());
                PlaySound(CrossbowShoot, Crossbow);
                
            }
            else if (player.CurrentHP <= 0)
            {
                DontShoot = true;
            }

            /*ShootTime += Time.deltaTime;
            if(ShootTime > ShootCoolTime)
            {
                ShootTime = 5;
            }*/
        }

    }
    void OnCollisionStay(Collision collision)       // Collision Stay 판정
    {
        if (collision.gameObject.CompareTag("HidingFloor"))     // Player가 HidingFloor를 밟고 있다면
        {
            DontShoot = true;
        }
        else if (!collision.gameObject.CompareTag("HidingFloor") && !player.IsPlayerDead)        // Player가 HidingFloor를 밟고 있지 않는 상황이라면
        {
            DontShoot = false;
        }
    }

    private IEnumerator ShootCoolDown()
    {
        IsShootCoolDown = true;
        yield return Delay;
        IsShootCoolDown = false;
    }

    public static void PlaySound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = false;
        audioPlayer.Play();
    }

    void OnTriggerEnter(Collider other)              // 무기 먹었을 때 공격 가능하도록
    {
        if (other.tag == "crossBow")
        {
            nearObject = other.gameObject;
            Debug.Log("석궁 획득");
            nearObject.SetActive(false);
            crossBowCount++;
        }
    }
}   



/*    else if (!collision.gameObject.CompareTag("HidingFloor"))        // Player가 HidingFloor를 밟고 있지 않는 상황이라면
{
    Speed = 10f;        // Speed 원상복구
    JumpPower = 20f;            // JumpPower 원상복구
    if (IsPlayerDead == true)
    {
        Speed = 0f;
        JumpPower = 0f;
        IsBanControl = true;
    }
}
*/