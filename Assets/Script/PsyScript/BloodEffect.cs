using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject bloodPrefab; // 블러드 이펙트 프리팹

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체가 특정 태그를 가진 경우 블러드 이펙트 생성
        if (collision.gameObject.CompareTag("RogueHooded"))
        {
            // 충돌 위치에 블러드 이펙트 생성
            ContactPoint contact = collision.contacts[0];
            Instantiate(bloodPrefab, contact.point, Quaternion.identity);
        }
    }
}

