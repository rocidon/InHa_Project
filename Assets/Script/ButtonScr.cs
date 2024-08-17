using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        Debug.Log("NewGame");
        SceneManager.LoadScene("_MinsungTest");
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

    public void OnClickEndLoadScene()
    {
        SceneManager.LoadScene("_MinsungTest1");
    }

    public void OnClickEndLoadScene2()
    {
        SceneManager.LoadScene("_MinsungTest");

    }
}
