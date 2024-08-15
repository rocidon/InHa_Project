using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public float speed;
    public float DefaultDamage;
    bool Is_Falling;
    // Start is called before the first frame update
    void Start()
    {
        speed = speed >= 1.0f ? speed : 5.0f;
        Is_Falling = true;
        DefaultDamage = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        RayHit();
    }

    void RayHit()
    {
        Vector3 ChkPos = transform.forward+transform.position;
        Debug.DrawRay(ChkPos, Vector3.down*0.5f, Color.green, 0.01f);
        if(Physics.Raycast(ChkPos, Vector3.down, out hit, 0.5f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Move();
            }
        }
        else
        {
            if(!Is_Falling)Turn();
        }
    }
    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void Turn()
    {
        Debug.Log("Turn");
        Vector3 BackVec = transform.forward * -1;
        if(BackVec != Vector3.zero)
        {
            transform.forward = BackVec;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIt Coll");
        Debug.Log(transform.position);
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Is_Falling = false;
            Debug.Log("inCollision");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Is_Falling = true;
            Debug.Log("OuCollision");
        }
    }
}
