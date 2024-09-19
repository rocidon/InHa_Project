using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 위아래 움직이는 장애물
public class UpDownObs : MonoBehaviour
{
    // 위아래 이동할 최대 거리
    public float moveDistance = 3f;
    // 장애물 이동 속도
    public float moveSpeed = 5f;

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");

        // 위아래 움직이는 장애물 장애물 충돌 시 밀리는 코드
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerMove>().blade++;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 충돌 방향 벡터를 계산
                Vector3 collisionDirection = transform.position - collision.transform.position;
                // 충돌 반응을 위해 힘을 적용
                rb.AddForce(collisionDirection.normalized * -300f);
            }


            Debug.Log("충돌 시작!");

        }

    }
// PingPong 주어진 거리 범위 내에서 계속해서 반복하는 값을 제공
}