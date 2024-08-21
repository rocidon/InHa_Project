// MoveToTarget
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject HidingPosition;
    public GameObject FloorOnPosition;

    private void OnTriggerStay(Collider other)      // ���� �� ���� �� ����
    {
     
;
        if (other.gameObject.CompareTag("FloorOnPosition") && Input.GetKey(KeyCode.X))
        {
            StartCoroutine(Hide());
            Debug.Log("�������ϴ�.");
        
        }

        if (other.gameObject.CompareTag("HidingPosition") && Input.GetKey(KeyCode.C))
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
        transform.GetComponent<Rigidbody>().isKinematic = true;
        while (HidingPosition.transform.position != transform.position)
        {
            yield return null;
            Debug.Log("����");
            transform.position = Vector3.MoveTowards(gameObject.transform.position, HidingPosition.transform.position, 0.1f);
        }
    }
    IEnumerator ReturnToFloor()
    {
        transform.GetComponent<Rigidbody>().isKinematic = false;
        while (FloorOnPosition.transform.position != transform.position)
        {
            yield return null;
            Debug.Log("Floor�� ���ƿ�");
            transform.position = Vector3.MoveTowards(gameObject.transform.position, FloorOnPosition.transform.position, 0.1f);
        }
    }
}
