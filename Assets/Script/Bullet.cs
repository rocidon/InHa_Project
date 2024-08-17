using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20.0f;

    public float force = 1.0f;

    private Rigidbody Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
       /* Rigid.AddForce(transform.forward * force);*/
    }

    void Update()
    {
        Rigid.AddForce(transform.forward * force);
        transform.Translate(new Vector3(0.05f, 0, 0));
    }
}
