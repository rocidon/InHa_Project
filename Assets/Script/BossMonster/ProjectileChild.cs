using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileChild : MonoBehaviour
{
    //�ݸ��� ó���� ���ִ� ��
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Playe Child");
        transform.parent.GetComponent<BossProjectile>().OnTriggerEnter(other);
    }
}
