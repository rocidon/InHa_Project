// Fire
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] Animator anime;
    public GameObject Bullet;
    public Transform FirePos;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }
    }
}
