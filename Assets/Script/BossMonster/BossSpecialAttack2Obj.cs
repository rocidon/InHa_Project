using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class BossSpecialAttack2Obj : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    [SerializeField]
    public float Height;
    [SerializeField]
    public float ImpactPoint;

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
            //StartPoint.y = transform.position.y - Height;
            fv.Normalize();
            transform.forward = fv;
            //Debug.Log(fv.x);
            WarningRange = transform.GetChild(1);
            WarningRange.GetComponent<MeshRenderer>().enabled = false;
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
            Destroy(gameObject);
        }
        //if (!other.CompareTag("Boss"))
        //{            
        //    Destroy(gameObject);
        //}
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
            if(dx >= ImpactPoint / 2)
            {
                WarningRange.GetComponent<MeshRenderer>().enabled = true;
            }
            dy = (dx * (dx - ImpactPoint)) * -1.0f;
            transform.Translate(Vector3.forward * DeltaTime * DSpeed);
            transform.position = new Vector3(transform.position.x, StartPoint.y + dy, transform.position.z);
            WarningRange.position = new Vector3(StartPoint.x + ImpactPoint*fv.x, StartPoint.y, StartPoint.z);
            //(ImpactPoint - dx)*fv.x
            Dtime += DeltaTime;
            yield return new WaitForSeconds(DeltaTime);
        }

        WarningRange.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
