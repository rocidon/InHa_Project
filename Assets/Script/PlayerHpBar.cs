using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField]
    private Slider playerHp; // HP 슬라이더

    private float maxHp = 100; // 최대 HP
    private float curHp; // 현재 HP

    void Start()
    {
        curHp = maxHp; // 현재 HP를 최대 HP로 초기화  
        playerHp.maxValue = maxHp; // 슬라이더의 최대 값을 설정
        playerHp.value = curHp; // 슬라이더의 초기 값을 설정
    }

    void Update()
    {
        HandleHp(); // Update에서 HP 슬라이더 업데이트
    }

    private void HandleHp()
    {
        playerHp.value = Mathf.Lerp(playerHp.value, curHp, Time.deltaTime * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name + "와(과) 충돌 발생");    //오브젝트와 충돌시 로그 출력

        if (collision.gameObject.CompareTag("Enemy"))
        {
            curHp -= 10;
            curHp = Mathf.Max(curHp, 0);
            HandleHp();
        }
    }
}
