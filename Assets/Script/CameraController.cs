using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   /* public float cameraSpeed = 5.0f;*/
    private Vector3 offset;

    public GameObject player;

    private void Start()
    {
        offset =transform.position - player.transform.position; 
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
       /* Vector3 dir = player.transform.position - transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(moveVector);*/
    }
}