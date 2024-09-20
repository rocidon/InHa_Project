using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossSkip1 : MonoBehaviour
{
    public BossMonster1 boss; // ���� ��ũ��Ʈ�� ������ ����
    public Button skipButton; // UI ��ư ����
    private float currentHealth;


    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnSkipButtonClick); // ��ư Ŭ�� �� �޼��� ����
    }

    void OnSkipButtonClick()
    {
        if(boss != null)
        {
            boss.NormalAttackCount = 5;
        }

    }
}
