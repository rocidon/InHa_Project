using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    // Slider UI ì»´í¬?ŒíŠ¸ ? ë‹¹
    [SerializeField] private Slider bossHp;

    // enemy ìµœë? ë°?ì´ˆê¸° ì²´ë ¥ ?¤ì •
    public float maxHp = 100;  
    private float curHp;


    // ì²´ë ¥ë°?falseë¡?ì´ˆê¸°??
   private bool isActive = false;

    void Start()
    {
        curHp = maxHp;

        // Slider ìµœëŒ“ê°’ê³¼ ì´ˆê¸°ê°?
        bossHp.maxValue = maxHp;
        bossHp.value = curHp;

        bossHp.gameObject.SetActive(isActive);

    }

    void Update()
    {
        UpdateHP();          

        //ì²´ë ¥??0?´í•˜ ?¼ë•Œ, ì²´ë ¥ë°?ë¹„í™œ?±í™”
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
        
        //ì¶©ëŒ???¤ë¸Œ?íŠ¸ ?œê·¸ê°€ "Player"?¼ë•Œ
        if (collision.gameObject.CompareTag("Player"))
        {
            // ì²´ë ¥ë°??œì„±??
            bossHp.gameObject.SetActive(isActive = true);

            curHp -= 10;

            //0?´í•˜ë¡??¨ì–´ì§€ì§€ ?Šë„ë¡??¤ì •
            curHp = Mathf.Max(curHp, 0);

            UpdateHP();
        }
    }
}
