using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    // Slider UI 컴포?�트 ?�당
    [SerializeField] private Slider bossHp;

    // enemy 최�? �?초기 체력 ?�정
    public float maxHp = 100;  
    private float curHp;


    // 체력�?false�?초기??
   private bool isActive = false;

    void Start()
    {
        curHp = maxHp;

        // Slider 최댓값과 초기�?
        bossHp.maxValue = maxHp;
        bossHp.value = curHp;

        bossHp.gameObject.SetActive(isActive);

    }

    void Update()
    {
        UpdateHP();          

        //체력??0?�하 ?�때, 체력�?비활?�화
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



    private void OnCollisionEnter(Collision collision)
    {
        
        //충돌???�브?�트 ?�그가 "Player"?�때
        if (collision.gameObject.CompareTag("Player"))
        {
            // 체력�??�성??
            bossHp.gameObject.SetActive(isActive = true);

            curHp -= 10;

            //0?�하�??�어지지 ?�도�??�정
            curHp = Mathf.Max(curHp, 0);

            UpdateHP();
        }
    }
}
