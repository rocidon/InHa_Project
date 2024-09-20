using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    // Slider UI ����
    [SerializeField] private Slider bossHp;
    [SerializeField] private BossMonster1 BossMonster;


    // ���� ���� ������ ������ ��.
    // boss �ִ� �� �ʱ� ü�� ����
    private float maxHp;
    private float curHp;

    // HP�� ó�� ����.
    //private bool isActive = false;

    void Start()
    {

        maxHp = BossMonster._MaxHealth;
        curHp = BossMonster._Health;

        bossHp.maxValue = maxHp;
        bossHp.value = curHp;

        //bossHp.gameObject.SetActive(isActive);

    }

    void Update()
    {
        curHp = BossMonster._Health;
        UpdateHP();

        if (curHp <= 0)
        {
            //bossHp.gameObject.SetActive(false);
            Debug.Log("Die");
        }
    }

    private void UpdateHP()
    {
        bossHp.value = curHp;
    }



    // �׽�Ʈ��
    //private void OnCollisionEnter(Collision collision)
    //{

    //    // �浹�� ������Ʈ�� �±װ� Player �ϴ�
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // ü�¹� Ȱ��ȭ
    //        bossHp.gameObject.SetActive(isActive = true);

    //        curHp -= 10;

    //        //0 ���Ϸ� �������� �ʵ���.
    //        curHp = Mathf.Max(curHp, 0);

    //        UpdateHP();
    //    }
    //}
}
