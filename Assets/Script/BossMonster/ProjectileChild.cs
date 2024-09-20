using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileChild : MonoBehaviour
{
    //콜리전 처리만 해주는 곳
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Playe Child");
        transform.parent.GetComponent<BossProjectile>().OnTriggerEnter(other);
    }
}
