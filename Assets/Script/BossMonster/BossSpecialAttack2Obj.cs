using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class BossSpecialAttack2Obj : MonoBehaviour
{
    [SerializeField]
    public GameObject Effect;
    [SerializeField]
    public GameObject FailEffect;
    [SerializeField]
    public float Height;
    [SerializeField]
    public float ImpactPoint;
    [SerializeField]
    GameObject Target;

    Transform WarningRange;
    float Duration;
    Vector3 StartPoint;
    Vector3 fv;
    void Start()
    {
        //ImpactPoint = Random.Range(4.0f, 7.0f);
        Duration = Random.Range(1.0f, 1.5f);
        StartPoint = transform.position;
        Target = GameObject.FindWithTag("Player");
        if (Target == null)
        {
            Debug.Log("Can't Find Target");
        }
        else
        {
            fv = new Vector3(Target.transform.position.x - transform.position.x, 0, 0);
            StartPoint = new Vector3(StartPoint.x, StartPoint.y - (Height+0.1f), StartPoint.z);
            //Debug.Log(StartPoint);
            fv.Normalize();
            transform.forward = fv;
            //Debug.Log(fv.x);
            WarningRange = transform.GetChild(1);
            WarningRange.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<SphereCollider>().enabled = false;
            StartCoroutine(Pattern());
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("Player"))
        {
            //Take Damage Player
            Debug.Log("Hit Player on Special Atk Obj");
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
        else
        {
            if (!other.CompareTag("Boss"))
            {
                Instantiate(FailEffect, transform.position, Quaternion.identity);
                Debug.Log("플레이어도 아니고 보스도 아님 : " + other.name);
            }
            //Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    IEnumerator Pattern()
    {
        float Dtime=0.0f;
        float DSpeed = ImpactPoint / Duration;
        float dx;
        float dy;

        while (Duration > Dtime)
        {
            float DeltaTime = Time.deltaTime;
            dx = Mathf.Abs(StartPoint.x - transform.position.x);
            dy = (dx * (dx - ImpactPoint)) * -1.0f;
            if (dx >= ImpactPoint / 2)
            {
                WarningRange.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponentInChildren<SphereCollider>().enabled = true;
            }
            transform.Translate(Vector3.forward * DeltaTime * DSpeed);
            transform.position = new Vector3(transform.position.x, StartPoint.y + dy, transform.position.z);
            WarningRange.position = new Vector3(StartPoint.x + ImpactPoint * fv.x, StartPoint.y, StartPoint.z);
            ////(ImpactPoint - dx)*fv.x
            Dtime += DeltaTime;
            yield return new WaitForSeconds(DeltaTime);
        }

        WarningRange.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
