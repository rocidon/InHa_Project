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
    public Animator anim;
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

    // ��ֹ� ���� �� ü�� ����
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle") && !playerMove.IsPlayerDead)
        {
            playerMove.CurrentHP -= 5;
            if(playerMove.CurrentHP <= 0)
            {
                playerMove.IsPlayerDead = true;
                anim.SetTrigger("Die");
                
            }
            Debug.Log("����");
        }
    }

}
