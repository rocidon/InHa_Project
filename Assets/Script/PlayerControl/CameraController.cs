// CameraController
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /* public float cameraSpeed = 5.0f;*/
    private Vector3 offset;     // 오프셋 생성

    public GameObject player;

    private void Start()
    {
        offset = transform.position - player.transform.position;     // 카메라와 플레이어 사이의 거리를 offset으로 설정
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;        // 카메라가 플레이어를 따라다니 도록 고정
        /* Vector3 dir = player.transform.position - transform.position;
         Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
         transform.Translate(moveVector);*/
    }
}