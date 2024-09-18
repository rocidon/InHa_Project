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

    // 일시정지 esc
    public void Pause()
    {

        pauseMenuCanvas.SetActive(true);

        AudioListener.volume = 0.4f;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // 계속하기
    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);

        // 배경음이 확정이 된다면, 전체 불륨이 아닌 배경음으로 바꿀예정.
        AudioListener.volume = 1f;

        Time.timeScale = 1f;
        GameIsPaused = false;
    }




    // 끝내기
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
    public void ReStartButton()
    {
        // 현재 활성화된 씬
        Scene currentScene = SceneManager.GetActiveScene();


        // 현재 씬을 로드
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


        // 필요 예상
        // 현재 씬 피통 = 씬 전환될 때 플레이어 현재 피통.
        // 기본으로 씬안에 적이 씬이 로드될때 피통이 초기화가 되거나 따로 설정.
        // 

    }

    // 폐기
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