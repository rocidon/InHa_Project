using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossClear : MonoBehaviour
{
    private CanvasGroup canvas;
    [SerializeField] private BossMonster1 BossMonster;

    private float curHp;

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossMonster._Health <= 0 && !isActive)
        {
            canvas = GetComponentInParent<CanvasGroup>();
            StartCoroutine(Fade());
            isActive = true;
        }
    }

    IEnumerator Fade()
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeOut()); 
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
