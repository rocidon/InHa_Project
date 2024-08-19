using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField]
    private Slider playerHp;

    private float maxHp = 100;
    private float curHp; //

    void Start()
    {
        curHp = maxHp; // 
        playerHp.maxValue = maxHp; //
        playerHp.value = curHp; // 
    }

    void Update()
    {
        HandleHp(); // Update?์ HP ?ฌ๋ผ?ด๋ ?๋ฐ?ดํธ
    }

    private void HandleHp()
    {
        playerHp.value = Mathf.Lerp(playerHp.value, curHp, Time.deltaTime * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name + "?(๊ณ? ์ถฉ๋ ๋ฐ์");    //?ค๋ธ?ํธ? ์ถฉ๋??๋ก๊ทธ ์ถ๋ ฅ

        if (collision.gameObject.CompareTag("Enemy"))
        {
            curHp -= 10;
            curHp = Mathf.Max(curHp, 0);
            HandleHp();
        }
    }
}
