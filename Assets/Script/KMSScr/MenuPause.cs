using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering;
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

        // ������� Ȯ���� �ȴٸ�, ��ü �ҷ��� �ƴ� ��������� �ٲܿ���.
        AudioListener.volume = 1f;

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {

        pauseMenuCanvas.SetActive(true);

        AudioListener.volume = 0.4f;
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
        //activeSelf ���� ������Ʈ�� Ȱ��ȭ ��������..
        if (pauseMenuCanvas.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }


    }


    public void ReStartButton()
    {
        // ���� Ȱ��ȭ�� ��
        Scene currentScene = SceneManager.GetActiveScene();

        // ���� ���� �ε�
        Resume();
        SceneManager.LoadScene(currentScene.name);


        // �ʿ� ����
        // ���� �� ���� = �� ��ȯ�� �� �÷��̾� ���� ����.
        // �⺻���� ���ȿ� ���� ���� �ε�ɶ� ������ �ʱ�ȭ�� �ǰų� ���� ����.
        // 

    }



}