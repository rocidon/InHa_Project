using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject HidingPosition;
    public GameObject FloorOnPosition;

    private void OnTriggerStay(Collider other)      // 숨을 수 있을 때 감지
    {
        if (other.gameObject.tag == "FloorOnPosition" && Input.GetKey(KeyCode.X))
        {
            StartCoroutine(Hide());
            Debug.Log("숨었습니다.");
        }

        if (other.gameObject.tag == "HidingPosition" && Input.GetKey(KeyCode.C))
        {
            StartCoroutine(ReturnToFloor());
            Debug.Log("Floor로 돌아왔습니다.");
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
            Debug.Log("숨기");
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
