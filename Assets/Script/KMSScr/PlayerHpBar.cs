using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField]private Slider playerHp;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private PlayerMove playerMove;

    private float maxHp;
    private float curHp;

    void Start()
    {
        maxHp = playerMove.MaxHP;
        curHp = playerMove.CurrentHP;

        playerHp.maxValue = maxHp;
        playerHp.value = curHp;

        UpdateHealthText();
    }

    void Update()
    {
        curHp = playerMove.CurrentHP;
        UpdateHP();
        UpdateHealthText();
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
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // 충돌한 오브젝트 태그가 "Enemy"일 때
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        curHp -= 10;
    //        // 0 이하로 떨어지지 않도록 설정
    //        curHp = Mathf.Max(curHp, 0);
    //    }
    //}
}
