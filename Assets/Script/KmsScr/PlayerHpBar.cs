using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    // Slider 체력 컴포넌트 할당
    [SerializeField]private Slider playerHp;        


    // Player 최대 및 초기 체력 설정
    private float maxHp = 100;     
    private float curHp;            

    void Start()
    {
        curHp = maxHp;              // 현재 체력을 최대 체력으로 초기화
        playerHp.maxValue = maxHp;  // 슬라이더에 최대 체력으로 설정
        playerHp.value = curHp;     // 슬라이
    }

    void Update()
    {
        UpdateHP();
    }


    private void UpdateHP()
    {
        playerHp.value = curHp;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트 태그가 "Enemy"일 때
        if (collision.gameObject.CompareTag("Enemy"))
        {
            curHp -= 10;
            // 0 이하로 떨어지지 않도록 설정
            curHp = Mathf.Max(curHp, 0);
        }
    }
}
