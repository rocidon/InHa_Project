using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField]
    private Slider playerHp;

    private float maxHp = 100;
    private float curHp; 

    void Start()
    {
        curHp = maxHp; 
        playerHp.maxValue = maxHp; 
        playerHp.value = curHp; 
    }

    void Update()
    {
        UpdateHP();
    }


    private void UpdateHP()
    {
        playerHp.value = curHp;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            curHp -= 10;
            curHp = Mathf.Max(curHp, 0);
        }
    }
}
