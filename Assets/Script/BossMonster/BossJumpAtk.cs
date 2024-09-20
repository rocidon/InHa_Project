using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossJumpAtk : MonoBehaviour
{
    [SerializeField]
    public GameObject Effect;
    [SerializeField]
    public GameObject SmashEffect;
    BoxCollider Range;
    [SerializeField]
    float BossAtk;
    private void Start()
    {
        BossAtk = GetComponentInParent<BossMonster1>()._Atk;
        BossAtk *= 1.5f;
        Range = GetComponent<BoxCollider>();
        SmashEffect.GetComponent<Transform>().localScale = new Vector3(5, 5, 5);
        /*콜라이더 세팅을 해줘야함*/

    }
    public void OnAtk()
    {
        Debug.Log("On Jump Atk Script!");
        Range.enabled = true;
        Instantiate(SmashEffect, transform.position, Quaternion.identity);
        StartCoroutine(RemainRange());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerMove>().TakeDamage(BossAtk);
            Debug.Log("Player Jump Hit");
            Instantiate(Effect, other.transform.position, Quaternion.identity);
        }
    }


    IEnumerator RemainRange()
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Off Jump Atk Script!");
        Range.enabled = false;
        
    }
}
