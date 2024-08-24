using UnityEngine;
using UnityEngine.SceneManagement;      //�� ���� ��� ���
public class ButtonScr : MonoBehaviour
{
    public void OnClickNewGame()
    {
        // "NewGame"Log ���
        Debug.Log("NewGame");                 
        // �Լ� ����� "_MinsungTest"�̶�� �̸��� �� ��ȯ
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
