using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    // Slider ü�� ������Ʈ �Ҵ�
    [SerializeField]private Slider playerHp;


    [SerializeField] private PlayerController player;
    //Player �ִ� �� �ʱ� ü�� ����
    private float maxHp;
    private float curHp;

    //[SerializeField] private PlayerMove playerMove;
    //private float maxHp;
    //private float curHp;

    void Start()
    {
        maxHp = player.maxHp;
        curHp = player.curHp;

        curHp = maxHp;
        playerHp.maxValue = maxHp;
        playerHp.value = curHp;


        /*  HP�� ������ �÷��̾� ���׼� ���� �����;���.
        maxHp = playerMove.maxHp;
        curHp = playerMove.CurrentHP;

        curHp = maxHp;
        playerHp.maxValue = maxHp;
        playerHp.value = curHp;
     
        */
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
