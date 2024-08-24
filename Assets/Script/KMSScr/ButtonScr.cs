using UnityEngine;
using UnityEngine.SceneManagement;      //씬 관련 기능 사용
public class ButtonScr : MonoBehaviour
{
    public void OnClickNewGame()
    {
        // "NewGame"Log 출력
        Debug.Log("NewGame");                 
        // 함수 실행시 "_MinsungTest"이라는 이름의 씬 전환
        SceneManager.LoadScene("IntroScene"); 
    }
    public void OnClickRoadGame()
    {
        Debug.Log("RoadGame");
    }
    public void OnClickOption()
    {
        Debug.Log("Option");
    }
    public void OnClickEnd()
    {
        Debug.Log("End");
    }

    public void SceneTest1()
    {
        Debug.Log("NewGame");
        SceneManager.LoadScene("_MinsungTest2");
    }

    public void SceneTest2()
    {
        Debug.Log("NewGame");
        SceneManager.LoadScene("_MinsungTest1");
    }
}
