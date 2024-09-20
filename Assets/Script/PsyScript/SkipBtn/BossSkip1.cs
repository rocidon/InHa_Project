using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossSkip1 : MonoBehaviour
{
    public BossMonster1 boss; // 보스 스크립트를 연결할 변수
    public Button skipButton; // UI 버튼 변수
    private float currentHealth;


    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnSkipButtonClick); // 버튼 클릭 시 메서드 연결
    }

    void OnSkipButtonClick()
    {
        if(boss != null)
        {
            boss.NormalAttackCount = 5;
        }

    }
}
