using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAtK2ObjChild : MonoBehaviour
{    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Play Special 2 Child");
        transform.parent.GetComponent<BossSpecialAttack2Obj>().OnTriggerEnter(other);
    }
}
