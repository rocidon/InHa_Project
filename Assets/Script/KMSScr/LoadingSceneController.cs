using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEditor.VersionControl;


public class LoadingSceneController : MonoBehaviour
{
    private static LoadingSceneController instance;
    public static LoadingSceneController Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<LoadingSceneController>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    instance = Create();
                }
            }
            return instance;
        }
    }

    private static LoadingSceneController Create()
    {
        return Instantiate(Resources.Load<LoadingSceneController>("LodingUI"));
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image progressBar;

    private string loadSceneName;
    private bool isLoading = false;
    public void LoadScene(string sceneName)
    {
        if (isLoading) return;
        isLoading = true;

        gameObject.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;

        loadSceneName = sceneName;
        StartCoroutine(LoadSceneProcess());
    }

    [SerializeField] private TMP_Text TipText;
    private string[] randomTips = {
        "포탈앞에서 'Z' 를 누르면 다음 스테이지로 이동합니다.",
        "게임의 목표를 설정해 보세요!",
        "방향키로 조작하고 점프를 합니다!",
    "보스를 잡아서 게임을 끝내자",
    "아 배고프다 내일 아침 뭐 먹지",
    "추석때 대구 내려가서 뭐하지"};

    [SerializeField] private TMP_Text LodingPercentText;


    private IEnumerator LoadSceneProcess()
    {
        int randomTip = UnityEngine.Random.Range(0, randomTips.Length);
        TipText.text = $"TIP : {randomTips[randomTip]}";

        progressBar.fillAmount = 0f;
        LodingPercentText.text = $"{(progressBar.fillAmount * 0):0}%";

        yield return StartCoroutine(Fade(true));

        AsyncOperation op = SceneManager.LoadSceneAsync(loadSceneName);
        op.allowSceneActivation = false;

        float timer = 0f;



        while (!op.isDone)
        {

            LodingPercentText.text = $"{(progressBar.fillAmount * 100):0}%";

            yield return null;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);

                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == loadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= OnSceneLoaded;
            isLoading = false;
        }
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;

        while (timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 3f;

            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);


        }

        if (!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }

}


