using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField]
    private Slider enemyHp;    // HP 슬라이더

    private float maxHp = 100;  // 최대 HP
    private float curHp;        // 현재 HP

    void Start()
    {
        curHp = maxHp;              // 현재 HP를 최대 HP로 초기화  
        enemyHp.maxValue = maxHp;  // 슬라이더의 최대 값을 설정
        enemyHp.value = curHp;     // 슬라이더의 초기 값을 설정
    }

    void Update()
    {
        HandleHp();                 //매 프레임마다 부드럽게 업데이트되도록 하기 위함
    }


        private void HandleHp()     //체력 업데이트 및 부드러운 효과
    {
        enemyHp.value = Mathf.Lerp(enemyHp.value, curHp, Time.deltaTime * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name + "와(과) 충돌 발생");    //오브젝트와 충돌시 로그 출력

        if (collision.gameObject.CompareTag("Player"))
        {
            curHp -= 10;
            curHp = Mathf.Max(curHp, 0);
            HandleHp();
        }
    }
}
