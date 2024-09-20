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
            Debug.Log(Target.name);
            Debug.Log(Target.transform);
            
            transform.LookAt(Target.transform.position + Vector3.up);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Boss"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log(other.name);
                other.GetComponent<PlayerMove>().TakeDamage(5.0f);
            }
            Destroy(gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
        
    }
}
