using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossSpecialGernerate : MonoBehaviour
{
    [SerializeField]
    public GameObject Attack;
    [SerializeField]
    public int Count;
    float ScaleX;
    float ScaleY;
    float AttackScaleX;
    float AttackScaleY;
    // Start is called before the first frame update
    void Start()
    {
        Count = Count < 4 ? 4 : Count;
        Vector3 StartPosition = transform.position;
        AttackScaleX = Attack.transform.localScale.x / 2;

        ScaleX = transform.localScale.x / 2;
        ScaleY = transform.GetComponent<CapsuleCollider>().height / 2;

        Vector3 OBjPos1 = StartPosition + new Vector3(ScaleX + AttackScaleX, ScaleY, 0);
        Vector3 OBjPos2 = StartPosition - new Vector3(ScaleX + AttackScaleX, -ScaleY, 0);
        Instantiate(Attack, OBjPos1, Quaternion.Euler(0, 90, 0));
        Instantiate(Attack, OBjPos2, Quaternion.Euler(0, -90, 0));

    }
}
