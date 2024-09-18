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

    private void UpdateHealthText()  // ü�� �ؽ�Ʈ ������Ʈ �޼���
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

    // �׽�Ʈ��
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // �浹�� ������Ʈ �±װ� "Enemy"�� ��
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        curHp -= 10;
    //        // 0 ���Ϸ� �������� �ʵ��� ����
    //        curHp = Mathf.Max(curHp, 0);
    //    }
    //}
}
