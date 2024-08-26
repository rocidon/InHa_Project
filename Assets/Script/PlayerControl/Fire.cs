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
    void OnCollisionStay(Collision collision)       // Collision Stay ����
    {
        if (collision.gameObject.CompareTag("HidingFloor"))     // Player�� HidingFloor�� ��� �ִٸ�
        {
            DontShoot = true;
        }
        else if (!collision.gameObject.CompareTag("HidingFloor"))        // Player�� HidingFloor�� ��� ���� �ʴ� ��Ȳ�̶��
        {
            DontShoot = false;
        }
    }
}

