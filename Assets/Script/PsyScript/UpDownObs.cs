using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ʒ� �����̴� ��ֹ�
public class UpDownObs : MonoBehaviour
{
    // ���Ʒ� �̵��� �ִ� �Ÿ�
    public float moveDistance = 3f;
    // ��ֹ� �̵� �ӵ�
    public float moveSpeed = 5f;

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�浹");

        // ���Ʒ� �����̴� ��ֹ� ��ֹ� �浹 �� �и��� �ڵ�
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerMove>().blade++;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // �浹 ���� ���͸� ���
                Vector3 collisionDirection = transform.position - collision.transform.position;
                // �浹 ������ ���� ���� ����
                rb.AddForce(collisionDirection.normalized * -300f);
            }


            Debug.Log("�浹 ����!");

        }

    }
// PingPong �־��� �Ÿ� ���� ������ ����ؼ� �ݺ��ϴ� ���� ����
}