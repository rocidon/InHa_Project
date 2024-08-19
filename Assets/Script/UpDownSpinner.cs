using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class UpDownSpinner : MonoBehaviour
{
    // À§¾Æ·¡
    float initPositionY;
    float initPositionX;
    public float distance;
    public float turningPoint;

    public bool turnSwitch;
    public float moveSpeed;

    
    
    void Awake()
    {
        if (gameObject.name == "BladeSpinner");
        {
            initPositionY = transform.position.y;
            turningPoint = initPositionY - distance;
        }
    }

    void upDown()
    {
        float currentPositionY = transform.position.y;
        if (currentPositionY >= initPositionY)
        {
            turnSwitch = false;
        }
        else if (currentPositionY <= initPositionY)
        {
            turnSwitch = true;
        }
        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(0, 1, 0)
                * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, -1, 0)
                * moveSpeed * Time.deltaTime;
        }
    }



    void Update()
    {
        if (gameObject.name == "BladeSpinner")
        {
            upDown();
        }
        
    }

}
