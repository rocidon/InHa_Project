using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BossSpecialGernerate : MonoBehaviour
{
    [SerializeField]
    public GameObject Attack;
    [SerializeField]
    public int Count;
    [SerializeField]
    public GameObject WarningRangePrefeb;
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

        StartCoroutine(Pattern(StartPosition));

        //Vector3 OBjPos1 = StartPosition + new Vector3(ScaleX + AttackScaleX, ScaleY, 0);
        //Vector3 OBjPos2 = StartPosition - new Vector3(ScaleX + AttackScaleX, -ScaleY, 0);
        //Instantiate(Attack, OBjPos1, Quaternion.Euler(0, 90, 0));
        //Instantiate(Attack, OBjPos2, Quaternion.Euler(0, -90, 0));

    }
    IEnumerator Pattern(Vector3 StartPosition)
    {
        GameObject ob1 = Instantiate(WarningRangePrefeb);
        GameObject ob2 = Instantiate(WarningRangePrefeb);
        SetObject(ob1);
        SetObject(ob2);
        float RangeScaleX = ob1.transform.localScale.x/2;
        Vector3 OBjPos1 = StartPosition + new Vector3(ScaleX + RangeScaleX, ScaleY, 0);
        Vector3 OBjPos2 = StartPosition - new Vector3(ScaleX + RangeScaleX, -ScaleY, 0);

        ob1.transform.position = OBjPos1;
        ob2.transform.position = OBjPos2;

        yield return new WaitForSeconds(2.5f);

        ob1.GetComponent<MeshRenderer>().enabled = false;
        ob2.GetComponent<MeshRenderer>().enabled = false;

        OBjPos1 = StartPosition + new Vector3(ScaleX + AttackScaleX, ScaleY, 0);
        OBjPos2 = StartPosition - new Vector3(ScaleX + AttackScaleX, -ScaleY, 0);

        Instantiate(Attack, OBjPos1, Quaternion.Euler(0, 90, 0));
        Instantiate(Attack, OBjPos2, Quaternion.Euler(0, -90, 0));
    }

    void SetObject(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().enabled = true;
        obj.transform.localScale = new Vector3(100, ScaleY, 1);
    }
}
