using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject bloodPrefab; // ���� ����Ʈ ������

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� Ư�� �±׸� ���� ��� ���� ����Ʈ ����
        if (collision.gameObject.CompareTag("RogueHooded"))
        {
            // �浹 ��ġ�� ���� ����Ʈ ����
            ContactPoint contact = collision.contacts[0];
            Instantiate(bloodPrefab, contact.point, Quaternion.identity);
        }
    }
}

