using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    // Slider UI 컴포?�트 ?�당
    [SerializeField] private Slider enemyHp;

    // enemy 최�? �?초기 체력 ?�정
    public float maxHp = 100;  
    private float curHp;

    // UI ?�소
    private RectTransform hpBarTransform;

    // 메인 카메??참조
    private Camera mainCamera;

    // 체력�?false�?초기??
   private bool isActive = false;

    void Start()
    {
        curHp = maxHp;

        // Slider 최댓값과 초기�?
        enemyHp.maxValue = maxHp;
        enemyHp.value = curHp;

        // 체력�?RectTransform ?�??
        hpBarTransform = enemyHp.GetComponent<RectTransform>();

        // 메인 카메???�??
        mainCamera = Camera.main;

        // 체력�??�성???��?
        enemyHp.gameObject.SetActive(isActive);

    }

    void Update()
    {
        UpdateHP();          
        UpdateUIPosition();

        //체력??0?�하 ?�때, 체력�?비활?�화
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
        //?�의 ?�재 ?�치?�서 y축으�?1만큼 ?�동
        Vector3 screenPosition 
            = mainCamera.WorldToScreenPoint(transform.position + new Vector3(0, 1f, 0));

        //?�면 좌표??맞게 체력�??�치 ?�데?�트
        hpBarTransform.position = screenPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        //충돌???�브?�트 ?�그가 "Player"?�때
        if (collision.gameObject.CompareTag("Player"))
        {
            // 체력�??�성??
            enemyHp.gameObject.SetActive(isActive = true);

            curHp -= 10;

            //0?�하�??�어지지 ?�도�??�정
            curHp = Mathf.Max(curHp, 0);

            UpdateHP();
        }
    }
}
