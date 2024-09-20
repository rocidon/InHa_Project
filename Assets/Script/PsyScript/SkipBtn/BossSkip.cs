using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSkip : MonoBehaviour
{
    public float maxHealth = 1000f;
    private float currentHealth;
    public Button skipButton;

    void Start()
    {
        currentHealth = maxHealth;
        skipButton.gameObject.SetActive(true); // 스킵 버튼 숨기기
    }

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (currentHealth < maxHealth * 0.1f) // HP가 10% 미만일 때
        {
            skipButton.gameObject.SetActive(true); // 스킵 버튼 보이기
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // HP가 0 미만으로 떨어지지 않게
    }

    public void OnSkipButtonPressed()
    {        
        Debug.Log("스킵 버튼이 눌렸습니다.");
    }
}
