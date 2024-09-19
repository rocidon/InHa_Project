using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeialObj1_Collsion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Playe Special Child");
        transform.parent.GetComponent<BossSpecialAttack1Obj>().OnTriggerEnter(other);
    }
}
