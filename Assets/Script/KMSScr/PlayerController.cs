using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float jump = 100.0f;

    public float maxHp = 100.0f;
    public float curHp;
    private Rigidbody rb;
    void Start()
    {
        curHp = maxHp;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }


        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(0, speed * Time.deltaTime, 0);
        //}


        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(0, -speed * Time.deltaTime, 0);
        //}



    }
}
