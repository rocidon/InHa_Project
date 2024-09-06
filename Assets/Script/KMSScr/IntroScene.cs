using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public float speed = 5.0f;



    // Update is called once per frame
    void Update()
    {
        float a = speed * Time.deltaTime;
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= 3000)
        {
            SceneManager.LoadScene("TutorialScene_Psy");
            Debug.Log("ASDFSADSDF");
        }
        else
        {
            Debug.Log(transform.position.y);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TutorialScene_Psy");
        }
    }

}
