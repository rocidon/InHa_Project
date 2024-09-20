using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBg : MonoBehaviour
{
    private CanvasGroup canvas;
    [SerializeField] private PlayerMove playerMove;
    private bool isGameOverBg;

    void Start()
    {
        isGameOverBg = false;
        canvas = GetComponentInParent<CanvasGroup>();
    }

    void Update()
    {
        if (playerMove.CurrentHP <= 0 && !isGameOverBg)
        {
            StartCoroutine(Fade());
            isGameOverBg = true;
        }
    }
    IEnumerator Fade()
    {
        yield return StartCoroutine(FadeIn()); // �г� ����
        //yield return new WaitForSeconds(2f); // 2�� ���
        //yield return StartCoroutine(FadeOut()); // �г� �ݱ�
    }

    IEnumerator FadeIn()
    {
        for (float alpha = 0; alpha <= 1; alpha += Time.deltaTime)
        {
            canvas.alpha = alpha;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        for (float alpha = 1; alpha >= 0; alpha -= Time.deltaTime)
        {
            canvas.alpha = alpha;
            yield return null;
        }
    }
}

