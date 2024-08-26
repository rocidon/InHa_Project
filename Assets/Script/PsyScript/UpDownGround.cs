using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownGround : MonoBehaviour
{
    // ���Ʒ� �̵��� �ִ� �Ÿ�
    public float moveDistance = 3f;
    // ��ֹ� �̵� �ӵ�
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private float timeCounter;

    void Start()
    {
        // ó�� ���� ��ġ
        startPosition = transform.position;
    }


    void Update()
    {
        // �ð��� ���� ��ֹ� ��ġ ���
        timeCounter += Time.deltaTime * moveSpeed;
        float newY = Mathf.PingPong(timeCounter, moveDistance) - (moveDistance / 2);
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }
}
