using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossJumpAtk : MonoBehaviour
{
    BoxCollider Range;
    float BossAtk;
    private void Start()
    {
        BossAtk = GetComponentInParent<BossMonster1>()._Atk;
        BossAtk *= 1.5f;
        Range = GetComponent<BoxCollider>();
        /*콜라이더 세팅을 해줘야함*/

    }
    public void OnAtk()
    {
        Debug.Log("On Jump Atk Script!");
        Range.enabled = true;
        StartCoroutine(RemainRange());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<PlayerMove>().TakeDamage(BossAtk);
            Debug.Log("Player Jump Hit");
        }
    }


    IEnumerator RemainRange()
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Off Jump Atk Script!");
        Range.enabled = false;
    }
}
