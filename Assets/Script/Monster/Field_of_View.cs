using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Field_of_View : MonoBehaviour
{
    [SerializeField] bool DebugMode = false;
    [Range(0f, 360f)]
    [SerializeField] float ViewAngle = 0f;
    [SerializeField] float SeeRadius = 1f;
    [SerializeField] float AtkRadius = 1f;
    [SerializeField] LayerMask TargetMask;
    [SerializeField] LayerMask ObstacleMask;
    public bool FindPlayer;
    public bool AtkPlayer;
    public float height = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        height = height >= 1.0f ? height : 1.0f;
        FindPlayer = false;
        AtkPlayer = false;
        SeeRadius = SeeRadius > 5.0f ? SeeRadius : 5.0f;
        AtkRadius = SeeRadius - 2.0f >=  1.0f ? SeeRadius-2.0f : 1.0f;
    }

    private void OnDrawGizmos()
    {
        Vector3 myPos = transform.position + (Vector3.up * height);
        float lookingAngle = transform.localEulerAngles.y - 90.0f;

        Vector3 RightDir = AngleToDir(lookingAngle + ViewAngle * 0.5f);
        Vector3 LeftDir = AngleToDir(lookingAngle - ViewAngle * 0.5f);
        //Vector3 LeftDir = AngleToDir(lookingAngle - 160.0f * 0.5f);
        Vector3 lookDir = AngleToDir(lookingAngle);
 

        if (DebugMode)
        {
            Gizmos.DrawWireSphere(myPos, SeeRadius);
            Gizmos.DrawWireSphere(myPos, AtkRadius);
            Debug.DrawRay(myPos, RightDir * SeeRadius, Color.red);
            Debug.DrawRay(myPos, LeftDir * SeeRadius, Color.blue);
            Debug.DrawRay(myPos, lookDir * SeeRadius, Color.cyan);
        }

        DetectedPlayer(myPos, lookDir);
    }

    Vector3 AngleToDir(float angle)
    {
        float radian = (angle) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f);
    }

    void DetectedPlayer(Vector3 Mypositon, Vector3 LookDir)
    {

        Collider[] Targets = Physics.OverlapSphere(Mypositon, SeeRadius, TargetMask);
        if (Targets.Length == 0) {
            FindPlayer = false;
            AtkPlayer = false;
            return;
        }
        foreach (Collider EnemyColl in Targets)
        {

            Vector3 targetPos = EnemyColl.transform.position;
            Vector3 targetDir = (targetPos - Mypositon).normalized;
            float distance = Mathf.Sqrt(Mathf.Pow((targetPos.x - Mypositon.x), 2) + Mathf.Pow((targetPos.y - Mypositon.y), 2) + Mathf.Pow((targetPos.z - Mypositon.z), 2));
            float targetAngle = Mathf.Acos(Vector3.Dot(LookDir, targetDir)) * Mathf.Rad2Deg;
            if(targetAngle <= ViewAngle && !Physics.Raycast(Mypositon, targetDir, SeeRadius, ObstacleMask))
            {                
                if (DebugMode) Debug.DrawLine(Mypositon, targetPos, Color.red);
                FindPlayer = true;
                Debug.Log("Player Positon : " + targetPos);
                if (distance <= AtkRadius && (transform.forward != targetDir))
                {
                    AtkPlayer = true;
                }
                else
                {
                    AtkPlayer = false;
                }
            }
            else
            {
                Debug.Log("??");
                AtkPlayer = false;
                FindPlayer = false;
            }
        }
    }
}
