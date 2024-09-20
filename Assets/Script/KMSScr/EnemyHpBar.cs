using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{


    // Slider UI 컴포넌트 할당
    [SerializeField] private Slider enemyHp;
    [SerializeField] private NormalMonster normalMonster;

    // enemy 최대 및 초기 체력 설정
    private float maxHp;
    private float curHp;


    // UI 요소
    private RectTransform hpBarTransform;

    // 카메라 참조
    private Camera playerCamera;

    // 체력바 false로 초기화
    //private bool isActive = false;

    void Start()
    {
        maxHp = normalMonster._MaxHealth;
        curHp = normalMonster._Health;

        // Slider 최댓값과 초기값
        enemyHp.maxValue = maxHp;
        enemyHp.value = curHp;


        // 체력바 RectTransform 저장
        hpBarTransform = enemyHp.GetComponent<RectTransform>();

        // 카메라 저장, 꼭 플레이어랑 연결되는 카메라여야함.
        // 현재는 "Camera" 라서 이렇게 사용.
        playerCamera = GameObject.Find("Camera").GetComponent<Camera>();

        // 체력바 활성화 여부
        //enemyHp.gameObject.SetActive(isActive);

    }

    void Update()
    {
        curHp = normalMonster._Health;
        UpdateHP();
        UpdateUIPosition();

        // 체력이 0이하 일때, 체력바 비활성화
        if (curHp <= 0)
        {
            enemyHp.gameObject.SetActive(false);
        }
    }


    private void UpdateHP()
    {
        enemyHp.value = curHp;
    }


    private void UpdateUIPosition()
    {
        // 적의 현재 위치에서 y축으로 1만큼 이동
        Vector3 screenPosition
            = playerCamera.WorldToScreenPoint(transform.position + new Vector3(0, 2f, 0));

        // 화면 좌표에 맞게 체력바 위치 업데이트
        hpBarTransform.position = screenPosition;
    }

    // 테스트용
    //private void OnCollisionEnter(Collision collision)
    //{

    //    // 충돌한 오브젝트 태그가 "Player" 일때
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // 체력바 활성화
    //       // enemyHp.gameObject.SetActive(isActive = true);

    //        //curHp -= 100;

    //        // 0이하로 떨어지지 않도록 설정.
    //       // curHp = Mathf.Max(curHp, 0);

    //        UpdateHP();
    //    }
    //}
}




