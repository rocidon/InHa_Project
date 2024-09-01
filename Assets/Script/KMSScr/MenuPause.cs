using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused;
    public GameObject pauseMenuCanvas;

    [SerializeField] private TMP_Text sceneNameText;

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        sceneNameText.text = currentSceneName;
        pauseMenuCanvas.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OnClickEnd()
    {
        Debug.Log("END");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void PauseButton()
    {
        //activeSelf 현재 오브젝트가 활성화 상태인지..
        if (pauseMenuCanvas.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }


    }



}
