using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject HidingPosition;
    public GameObject FloorOnPosition;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FloorOnPosition" && Input.GetKey(KeyCode.X))
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, HidingPosition.transform.position, 0.05f);
            Debug.Log("숨기 가능합니다.");
        }
    }
  /*  private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FloorOnPosition" && Input.GetKey(KeyCode.X))
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, HidingPosition.transform.position, 0.05f);
            Debug.Log("숨기 가능합니다.");
        }
    }*/
    void Update()
    {

        /*if (transform.gameObject.tag == "FloorOnPosition")
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, HidingPosition.transform.position, 0.05f);
        }*/
/*        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, FloorOnPosition.transform.position, 0.05f);
        }*/

    }
}
