using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject HidingPosition;
    public GameObject FloorOnPosition;

    private void OnTriggerStay(Collider other)      // ���� �� ���� �� ����
    {
        if (other.gameObject.tag == "FloorOnPosition" && Input.GetKey(KeyCode.X))
        {
            StartCoroutine(Hide());
            Debug.Log("�������ϴ�.");
        }

        if (other.gameObject.tag == "HidingPosition" && Input.GetKey(KeyCode.C))
        {
            StartCoroutine(ReturnToFloor());
            Debug.Log("Floor�� ���ƿԽ��ϴ�.");
        }

    }

    void Update()
    {

    }

    IEnumerator Hide()
    {
        while (HidingPosition.transform.position != transform.position)
        {
            yield return null;
            Debug.Log("����");
            transform.position = Vector3.MoveTowards(gameObject.transform.position, HidingPosition.transform.position, 0.05f);
        }
    }
    IEnumerator ReturnToFloor()
    {
        while (FloorOnPosition.transform.position != transform.position)
        {
            yield return null;

            transform.position = Vector3.MoveTowards(gameObject.transform.position, FloorOnPosition.transform.position, 0.05f);
        }
    }
}
