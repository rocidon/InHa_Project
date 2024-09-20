using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    // Slider UI 설정
    [SerializeField] private Slider bossHp;
    [SerializeField] private BossMonster1 BossMonster;


    // 따로 참조 받으면 지워도 됨.
    // boss 최대 및 초기 체력 설정
    private float maxHp;
    private float curHp;

    // HP바 처음 상태.
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



    // 테스트용
    //private void OnCollisionEnter(Collision collision)
    //{

    //    // 충돌한 오브젝트의 태그가 Player 일대
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // 체력바 활성화
    //        bossHp.gameObject.SetActive(isActive = true);

    //        curHp -= 10;

    //        //0 이하로 떨어지지 않도록.
    //        curHp = Mathf.Max(curHp, 0);

    //        UpdateHP();
    //    }
    //}
}
