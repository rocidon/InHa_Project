using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    // Slider 체력 컴포넌트 할당
    [SerializeField]private Slider playerHp;
    [SerializeField] private TextMeshProUGUI healthText;


    //[SerializeField] private PlayerController player;
    //Player 최대 및 초기 체력 설정
    public float maxHp = 100;
    private float curHp;
    //[SerializeField] private PlayerMove playerMove;
    //private float maxHp;
    //private float curHp;

    void Start()
    {
        curHp = maxHp;
        playerHp.maxValue = maxHp;
        playerHp.value = curHp;
        UpdateHealthText();  // 매 프레임마다 텍스트 업데이트

        //maxHp = player.maxHp;
        //curHp = player.curHp;

        //curHp = maxHp;
        //playerHp.maxValue = maxHp;
        //playerHp.value = curHp;


        /*  HP가 설정된 플레이어 한테서 정보 가져와야함.
        maxHp = playerMove.maxHp;
        curHp = playerMove.CurrentHP;

        curHp = maxHp;
        playerHp.maxValue = maxHp;
        playerHp.value = curHp;
     
        */
    }

    void Update()
    {
        UpdateHealthText();

        UpdateHP();
    }

    private void UpdateHealthText()  // 체력 텍스트 업데이트 메서드
    {
        if (healthText != null)
        {
            healthText.text = $"{curHp} / {maxHp}";
        }
    }
    private void UpdateHP()
    {
        playerHp.value = curHp;
    }

    // 테스트용
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
