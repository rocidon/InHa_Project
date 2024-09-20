using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingPlayer : MonoBehaviour
{
    public float AtkRange;
    public float DetectRange;
    [SerializeField]
    public bool FindPlayer;
    [SerializeField]
    public bool AtkPlayer;
    [SerializeField]
    float Distance;
    Vector3 Dir;

    private void Awake()
    {
        FindPlayer = false;
        AtkPlayer = false;
        Distance = 0;
    }

    private void Start()
    {
        DetectRange = DetectRange < 5.0f ? 5.0f : DetectRange;
        AtkRange = AtkRange <2.0f ? 2.0f : AtkRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Distance = Vector3.Distance(transform.position, other.transform.position);
            Distance = Mathf.Abs(transform.position.x - other.transform.position.x);
           
            Dir = other.transform.position - transform.position;
            Dir.Normalize();
            //Debug.Log("Pl Range! : " + Dir);
            //Debug.Log("Playernge! : " + transform.forward);

            if (Dir.x * transform.forward.x > 0)
            {
                if (Vector3.Dot(Dir, transform.forward) >= Mathf.Cos(30.0f * Mathf.Deg2Rad))
                {
                    Debug.Log("Detect Player! : " + (Dir.x * transform.forward.x > 0));
                    FindPlayer = true;
                    if (Distance <= AtkRange)
                    {
                        Debug.Log("Attack Player! : " + (Distance <= AtkRange));
                        AtkPlayer = true;
                    }
                }
            }
            else
            {
                FindPlayer = false;
                AtkPlayer = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Distance = 0.0f;
            FindPlayer = false;
            AtkPlayer = false;
            //Debug.Log("Player out Range! : " + Distance);
        }
    }
}
