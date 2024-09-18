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
    public GameObject noReStart;
    [SerializeField] private TMP_Text sceneNameText;

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "TutorialScene_Psy")
        {
            sceneNameText.text = "TUTORIAL";
        }
        else if (currentSceneName == "StageScene1_Psy")
        {
            sceneNameText.text = "STAGE 01";
        }
        else if (currentSceneName == "StageScene2_Psy")
        {
            sceneNameText.text = "STAGE 02";
        }
        else if (currentSceneName == "StageScene3_Psy")
        {
            sceneNameText.text = "STAGE 03";
        }
        else if (currentSceneName == "BossScene_Psy")
        {
            sceneNameText.text = "STAGE BOSS";
        }

        pauseMenuCanvas.SetActive(false);
        //noReStart.SetActive(false);


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

    // �Ͻ����� esc
    public void Pause()
    {

        pauseMenuCanvas.SetActive(true);

        AudioListener.volume = 0.4f;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // ����ϱ�
    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);

        // ������� Ȯ���� �ȴٸ�, ��ü �ҷ��� �ƴ� ��������� �ٲܿ���.
        AudioListener.volume = 1f;

        Time.timeScale = 1f;
        GameIsPaused = false;
    }




    // ������
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
        LoadingSceneController.Instance.LoadScene(currentScene.name);
        Resume();

        //{
        //    if (currentScene.name == "StoreScene_Psy")
        //    {
        //        //NoReStart();
        //        Debug.Log("False");

        //    }
        //    else if (currentScene.name == "BossScene_Psy")
        //    {
        //        LoadingSceneController.Instance.LoadScene("StoreScene_Psy");
        //        Resume();
        //    }
        //    else
        //    {
        //    }


        // �ʿ� ����
        // ���� �� ���� = �� ��ȯ�� �� �÷��̾� ���� ����.
        // �⺻���� ���ȿ� ���� ���� �ε�ɶ� ������ �ʱ�ȭ�� �ǰų� ���� ����.
        // 

    }

    // ���
    //public void NoReStart()
    //{
    //    if (noReStart.activeSelf == false)
    //        noReStart.SetActive(true);
    //    else
    //    {
    //        noReStart.SetActive(false);
    //    }

    //}







}