using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNormalAttack : MonoBehaviour
{
    BoxCollider Range;
    float BossAtk;
    void Start()
    {
        BossAtk = GetComponentInParent<BossMonster1>()._Atk;
        Range = GetComponent<BoxCollider>();
    }

    public void OnAtk()
    {
        Debug.Log("On Normal Atk Script!");
        Range.enabled = true;
        StartCoroutine(RemainRange());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<PlayerMove>().TakeDamage(BossAtk);
            Debug.Log("Player Normal Hit");
        }
    }

    IEnumerator RemainRange()
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Off Normal Atk Script!");
        Range.enabled = false;
    }
}
