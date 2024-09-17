using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField]
    public GameObject Effect;
    [SerializeField]
    GameObject Target;
    [SerializeField]
    float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Speed = 10.0f;
        Target = GameObject.FindWithTag("Player");
        if (Target.CompareTag("Player"))
        {
            transform.LookAt(Target.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Play Parent");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
        if(!other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
