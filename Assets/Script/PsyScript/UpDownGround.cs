using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownGround : MonoBehaviour
{
    // 위아래 이동할 최대 거리
    public float moveDistance = 3f;
    // 장애물 이동 속도
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private float timeCounter;

    void Start()
    {
        // 처음 시작 위치
        startPosition = transform.position;
    }


    void Update()
    {
        // 시간에 따른 장애물 위치 계산
        timeCounter += Time.deltaTime * moveSpeed;
        float newY = Mathf.PingPong(timeCounter, moveDistance) - (moveDistance / 2);
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }
}
