using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    // Slider ü�� ������Ʈ �Ҵ�
    [SerializeField]private Slider playerHp;        


    // Player �ִ� �� �ʱ� ü�� ����
    private float maxHp = 100;     
    private float curHp;            

    void Start()
    {
        curHp = maxHp;              // ���� ü���� �ִ� ü������ �ʱ�ȭ
        playerHp.maxValue = maxHp;  // �����̴��� �ִ� ü������ ����
        playerHp.value = curHp;     // ������
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
        // �浹�� ������Ʈ �±װ� "Enemy"�� ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            curHp -= 10;
            // 0 ���Ϸ� �������� �ʵ��� ����
            curHp = Mathf.Max(curHp, 0);
        }
    }
}
