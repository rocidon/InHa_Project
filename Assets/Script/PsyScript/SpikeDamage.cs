using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 스파이크 장애물 충돌 시 밀리는 코드
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().spike++;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 충돌 방향 벡터를 계산
                Vector3 collisionDirection = transform.position - collision.transform.position;
                // 충돌 반응을 위해 힘을 적용
                rb.AddForce(collisionDirection.normalized * -200f);
            }


            Debug.Log("충돌 시작!");

        }
    }
}
