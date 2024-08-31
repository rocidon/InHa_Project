using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpecialAttack : MonoBehaviour
{
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Special Hit Player!!!");
            //单固瘤 贸府 -> 溜荤 贸府
            //PlayerClass player = collsion.gameObject.GetComponent<NormalMonster>();
            //float playerHP = Get playerHP(); <- MAX HP
            //player.takeDamage(playerHP);
        }
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Detroy Floor");
            Destroy(other.gameObject);
        }
    }
}
