using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    // Slider UI ì»´í¬?ŒíŠ¸ ? ë‹¹
    [SerializeField] private Slider enemyHp;

    // enemy ìµœë? ë°?ì´ˆê¸° ì²´ë ¥ ?¤ì •
    public float maxHp = 100;  
    private float curHp;

    // UI ?”ì†Œ
    private RectTransform hpBarTransform;

    // ë©”ì¸ ì¹´ë©”??ì°¸ì¡°
    private Camera mainCamera;

    // ì²´ë ¥ë°?falseë¡?ì´ˆê¸°??
   private bool isActive = false;

    void Start()
    {
        curHp = maxHp;

        // Slider ìµœëŒ“ê°’ê³¼ ì´ˆê¸°ê°?
        enemyHp.maxValue = maxHp;
        enemyHp.value = curHp;

        // ì²´ë ¥ë°?RectTransform ?€??
        hpBarTransform = enemyHp.GetComponent<RectTransform>();

        // ë©”ì¸ ì¹´ë©”???€??
        mainCamera = Camera.main;

        // ì²´ë ¥ë°??œì„±???¬ë?
        enemyHp.gameObject.SetActive(isActive);

    }

    void Update()
    {
        UpdateHP();          
        UpdateUIPosition();

        //ì²´ë ¥??0?´í•˜ ?¼ë•Œ, ì²´ë ¥ë°?ë¹„í™œ?±í™”
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
        //?ì˜ ?„ì¬ ?„ì¹˜?ì„œ yì¶•ìœ¼ë¡?1ë§Œí¼ ?´ë™
        Vector3 screenPosition 
            = mainCamera.WorldToScreenPoint(transform.position + new Vector3(0, 1f, 0));

        //?”ë©´ ì¢Œí‘œ??ë§ê²Œ ì²´ë ¥ë°??„ì¹˜ ?…ë°?´íŠ¸
        hpBarTransform.position = screenPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        //ì¶©ëŒ???¤ë¸Œ?íŠ¸ ?œê·¸ê°€ "Player"?¼ë•Œ
        if (collision.gameObject.CompareTag("Player"))
        {
            // ì²´ë ¥ë°??œì„±??
            enemyHp.gameObject.SetActive(isActive = true);

            curHp -= 10;

            //0?´í•˜ë¡??¨ì–´ì§€ì§€ ?Šë„ë¡??¤ì •
            curHp = Mathf.Max(curHp, 0);

            UpdateHP();
        }
    }
}
