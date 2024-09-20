using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossSpecialAttack1Obj : MonoBehaviour
{
    [SerializeField]
    public GameObject Effect;
    float Speed;
    float Height;
    float ObjHeight;
    float GoalHeight;
    float DTime;
    Transform WarningRange;
    Transform tmp;
    // Start is called before the first frame update
    void Start()
    {
        WarningRange = transform.GetChild(1);
        WarningRange.GetComponent<MeshRenderer>().enabled = true;
        WarningRange.transform.localScale = new Vector3(1, 100, 1);
        tmp = transform.GetChild(0);
        tmp.GetComponent<BoxCollider>().enabled = false; 
        ObjHeight = tmp.GetComponent<BoxCollider>().size.y * tmp.localScale.y;
        
        float RangeScaleY = WarningRange.transform.localScale.y;
        WarningRange.transform.position =
            new Vector3(transform.position.x,
            transform.position.y + (RangeScaleY/2+ ObjHeight),
            transform.position.z);

        //GoalHeight = tmp.GetComponent<BoxCollider>().size.y;
        DTime = 0;
        Height = transform.position.y;
        GoalHeight = Height + ObjHeight - 0.1f;
        //Debug.Log(ObjHeight);

        Speed = 10.0f;
        StartCoroutine(Pattern());
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player on Special Atk Obj");
            other.GetComponent<PlayerMove>().TakeDamage(20.0f);
            Instantiate(Effect, other.transform.position, Quaternion.identity);
        }
    }

    IEnumerator Pattern()
    {
        yield return new WaitForSeconds(1.0f);
        tmp.GetComponent<BoxCollider>().enabled = true;
        WarningRange.GetComponent<MeshRenderer>().enabled = false;

        while (true)
        {
            DTime = Time.deltaTime;
            if (GoalHeight <= transform.position.y) break;
            transform.Translate(Vector3.up * Speed * DTime);
            yield return new WaitForSeconds(DTime);
        }

        tmp.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
