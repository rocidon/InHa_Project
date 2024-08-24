// Fire
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] Animator anime;
    public GameObject Bullet;
    public Transform FirePos;
    bool DontShoot = false;
    void Update()
    {
        if (!DontShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            }
        }
    }
    void OnCollisionStay(Collision collision)       // Collision Stay 판정
    {
        if (collision.gameObject.CompareTag("HidingFloor"))     // Player가 HidingFloor를 밟고 있다면
        {
            DontShoot = true;
        }
        else if (!collision.gameObject.CompareTag("HidingFloor"))        // Player가 HidingFloor를 밟고 있지 않는 상황이라면
        {
            DontShoot = false;
        }
    }
}

