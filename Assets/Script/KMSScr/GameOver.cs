using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private GameObject gameOverWindow;

    private bool isGameOver;

    void Start()
    {
        isGameOver = false;
    }
    void Update()
    {
        if (playerMove.CurrentHP <= 0 && !isGameOver)
        {
            StartCoroutine(GameOverCheck(1f));
            isGameOver = true;
        }
    }
    private IEnumerator GameOverCheck(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverWindow.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOverButton()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        LoadingSceneController.Instance.LoadScene(currentScene.name);
        gameOverWindow.gameObject.SetActive(false);

    }

}
