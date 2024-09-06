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

    private AudioSource Crossbow;
    public AudioClip CrossbowShoot;
    void Start()
    {
        Crossbow = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (!DontShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !IsShootCoolDown)
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
    void OnCollisionStay(Collision collision)       // Collision Stay ����
    {
        if (collision.gameObject.CompareTag("HidingFloor"))     // Player�� HidingFloor�� ��� �ִٸ�
        {
            DontShoot = true;
        }
        else if (!collision.gameObject.CompareTag("HidingFloor") && !player.IsPlayerDead)        // Player�� HidingFloor�� ��� ���� �ʴ� ��Ȳ�̶��
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
}   



/*    else if (!collision.gameObject.CompareTag("HidingFloor"))        // Player�� HidingFloor�� ��� ���� �ʴ� ��Ȳ�̶��
{
    Speed = 10f;        // Speed ���󺹱�
    JumpPower = 20f;            // JumpPower ���󺹱�
    if (IsPlayerDead == true)
    {
        Speed = 0f;
        JumpPower = 0f;
        IsBanControl = true;
    }
}
*/