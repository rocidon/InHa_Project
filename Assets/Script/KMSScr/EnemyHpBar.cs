using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{


    // Slider UI ������Ʈ �Ҵ�
    [SerializeField] private Slider enemyHp;
    [SerializeField] private NormalMonster normalMonster;

    // enemy �ִ� �� �ʱ� ü�� ����
    private float maxHp;  
    private float curHp;


    // UI ���
    private RectTransform hpBarTransform;

    // ���� ī�޶� ����
    private Camera mainCamera;

    // ü�¹� false�� �ʱ�ȭ
   private bool isActive = false;

    void Start()
    {
        maxHp = normalMonster._Health;
        curHp = normalMonster._Health;

        // Slider �ִ񰪰� �ʱⰪ
        enemyHp.maxValue = maxHp;
        enemyHp.value = curHp;


        //�ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
        //maxHp = ������.maxHp;
        //curHp = ������.CurrentHP;

        //curHp = maxHp;
        //������.maxValue = maxHp;
        //������.value = curHp;
        //�ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�

        // ü�¹� RectTransform ����
        hpBarTransform = enemyHp.GetComponent<RectTransform>();

        // ī�޶� ����, �� �÷��̾�� ����Ǵ� ī�޶󿩾���.
        // ����� "Camera" �� �̷��� ���.
        mainCamera = GameObject.Find("Camera").GetComponent<Camera>();


        // ü�¹� Ȱ��ȭ ����
        enemyHp.gameObject.SetActive(isActive);

    }

    void Update()
    {
        UpdateHP();          
        UpdateUIPosition();

        // ü���� 0���� �϶�, ü�¹� ��Ȱ��ȭ
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
        // ���� ���� ��ġ���� y������ 1��ŭ �̵�
        Vector3 screenPosition 
            = mainCamera.WorldToScreenPoint(transform.position + new Vector3(0, 1f, 0));

        // ȭ�� ��ǥ�� �°� ü�¹� ��ġ ������Ʈ
        hpBarTransform.position = screenPosition;
    }

    // �׽�Ʈ��
    //private void OnCollisionEnter(Collision collision)
    //{
        
    //    // �浹�� ������Ʈ �±װ� "Player" �϶�
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // ü�¹� Ȱ��ȭ
    //        enemyHp.gameObject.SetActive(isActive = true);

    //        curHp -= 10;

    //        // 0���Ϸ� �������� �ʵ��� ����.
    //        curHp = Mathf.Max(curHp, 0);

    //        UpdateHP();
    //    }
    //}
}




 