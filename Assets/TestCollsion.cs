using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollsion : MonoBehaviour
{
    Vector3 size = new(1, 1, 1);
    public float Damage;
    private void Update()
    {
        Collider[] col = Physics.OverlapBox(transform.position, size);
        if(col.Length > 0)
        {
            //Debug.Log(col[0].name);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            NormalMonster nor = other.gameObject.GetComponent<NormalMonster>();
            nor.TakeDamage(Damage);
        }
        //Debug.Log("on Enter");
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, size);
    }
}
