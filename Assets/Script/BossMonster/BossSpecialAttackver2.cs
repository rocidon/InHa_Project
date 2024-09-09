using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAttackver2 : MonoBehaviour
{
    [SerializeField]
    public GameObject ThrowStone;

    float Height;
    // Start is called before the first frame update
    void Start()
    {
        Height = GetComponent<CapsuleCollider>().height * transform.localScale.y;
    }
    public void OnAtk()
    {
        Vector3 StartPosition = transform.position;
        StartCoroutine(Pattern(StartPosition));
    }
    IEnumerator Pattern(Vector3 StartPosition)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.05f);
            SpawnObject(StartPosition);
        }
    }
    void SpawnObject(Vector3 StartPosition)
    {
        Vector3 p = new Vector3(StartPosition.x, StartPosition.y+Height, StartPosition.z);
        GameObject tmp = Instantiate(ThrowStone, p, Quaternion.identity);
        tmp.GetComponent<BossSpecialAttack2Obj>().Height = Height;
    }

}
