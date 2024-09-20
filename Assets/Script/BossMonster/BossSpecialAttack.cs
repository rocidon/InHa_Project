using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpecialAttack : MonoBehaviour
{
    [SerializeField]
    public GameObject Effect;
    [SerializeField]
    public float Speed;
    private void Start()
    {
        Speed = Speed < 10.0f ? 10.0f : Speed;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //transform.Translate(transform.forward * Speed * Time.deltaTime);
        //transform.Rotate(new Vector3(2*Speed*Time.deltaTime,0,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Special Hit Player!!!");
            //单固瘤 贸府 -> 溜荤 贸府
            PlayerMove P = other.gameObject.GetComponent<PlayerMove>();
            P.TakeDamage(P.MaxHP);

        }
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Detroy Floor");
            Destroy(other.gameObject);
        }
        Instantiate(Effect, transform.position, Quaternion.identity);
    }
}
