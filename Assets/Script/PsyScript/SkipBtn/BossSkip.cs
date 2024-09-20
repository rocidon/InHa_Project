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
        skipButton.gameObject.SetActive(true); // ��ŵ ��ư �����
    }

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (currentHealth < maxHealth * 0.1f) // HP�� 10% �̸��� ��
        {
            skipButton.gameObject.SetActive(true); // ��ŵ ��ư ���̱�
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // HP�� 0 �̸����� �������� �ʰ�
    }

    public void OnSkipButtonPressed()
    {        
        Debug.Log("��ŵ ��ư�� ���Ƚ��ϴ�.");
    }
}
