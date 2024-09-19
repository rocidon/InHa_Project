using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class TestPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    float HP;

    private void Start()
    {
        HP = 10000;
    }
    void Update()
    {

    }

    public void TakeDamage(float Damage)
    {
        HP -= Damage;
        Debug.Log("hited : " + HP);

        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -4, ForceMode.Impulse);
    }
}
