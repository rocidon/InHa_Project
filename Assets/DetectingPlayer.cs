using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingPlayer : MonoBehaviour
{
    public float AtkRange;
    public float DetectRange;
    [SerializeField]
    bool FindPlayer;
    [SerializeField]
    bool AtkPlayer;
    [SerializeField]
    float Distance;
    Vector3 Fov;

    private void Awake()
    {
        FindPlayer = false;
        AtkPlayer = false;
        Distance = 0;
    }

    private void Start()
    {
        AtkRange = AtkRange <2.0f ? 2.0f : AtkRange;
        DetectRange = DetectRange < 5.0f ? 5.0f : DetectRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Player In Range! : " + Distance);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Player Stay Range! : " + Distance);
            if(Distance < 1)
            {

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Distance = 0.0f;
            Debug.Log("Player out Range! : " + Distance);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
