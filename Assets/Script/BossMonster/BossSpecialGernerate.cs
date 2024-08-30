using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialGernerate : MonoBehaviour
{
    [SerializeField]
    public GameObject Attack;
    float ScaleX;
    float AttackScaleX;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 StartPosition = transform.position;
        AttackScaleX = Attack.transform.localScale.x / 2;
        ScaleX = transform.localScale.x / 2;
        Vector3 OBjPos1 = StartPosition + new Vector3(ScaleX + AttackScaleX, 0, 0);
        Vector3 OBjPos2 = StartPosition - new Vector3(ScaleX + AttackScaleX, 0, 0);
        Instantiate(Attack, OBjPos1, Quaternion.Euler(0, 90, 0));
        Instantiate(Attack, OBjPos2, Quaternion.Euler(0, -90, 0));

    }
}
