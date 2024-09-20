using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    private CanvasGroup canvas;

    [SerializeField] private TMP_Text sceneNameText;

 
        void Start()
    {

        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "TutorialScene_Psy")
        {
            sceneNameText.text = "Tutorial";
        }
        else if (currentSceneName == "StageScene1_Psy")
        {
            sceneNameText.text = "Stage 01";
        }
        else if (currentSceneName == "StageScene2_Psy")
        {
            sceneNameText.text = "Stage 02";
        }
        else if (currentSceneName == "StageScene3_Psy")
        {
            sceneNameText.text = "Stage 03";
        }
        else if (currentSceneName == "BossScene_Psy")
        {
            sceneNameText.text = "Stage Boss";
        }


        canvas = GetComponentInParent<CanvasGroup>();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return StartCoroutine(FadeIn()); // �г� ����
        yield return new WaitForSeconds(2f); // 2�� ���
        yield return StartCoroutine(FadeOut()); // �г� �ݱ�
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
        canvas.alpha = 0;
    }

}

