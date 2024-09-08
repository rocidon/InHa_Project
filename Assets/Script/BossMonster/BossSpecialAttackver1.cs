using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAttackver1 : MonoBehaviour
{
    [SerializeField]
    public GameObject UpStone;
    float Width;
    float ObjWidth;
    float ObjHeight;
    float StartPosY;
    // Start is called before the first frame update
    void Start()
    {
        

        Width = transform.localScale.x/2;
        if (UpStone == null)
        {
            Debug.Log("UpStone is Null set Object");
        }
        else
        {
            Transform tmp = UpStone.transform.GetChild(0);
            ObjWidth = tmp.GetComponent<BoxCollider>().size.x * tmp.localScale.x;
            ObjHeight = tmp.GetComponent<BoxCollider>().size.y * tmp.localScale.y;
            StartPosY = transform.position.y - (ObjHeight);
        }
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
            yield return new WaitForSeconds(0.15f);
            SpawnStone(StartPosition, i);
        }
    }

    void SpawnStone(Vector3 StartPosition, int i)
    {
        Vector3 OBjPos1 = new Vector3(StartPosition.x + (Width + ObjWidth/2), StartPosY, StartPosition.z);
        OBjPos1 += new Vector3(ObjWidth * i, 0, 0);
        //Debug.Log(OBjPos1);
        Vector3 OBjPos2 = new Vector3(StartPosition.x - (Width + ObjWidth / 2), StartPosY, StartPosition.z);
        OBjPos2 -= new Vector3(ObjWidth * i, 0, 0);

        Instantiate(UpStone, OBjPos1, Quaternion.Euler(0, 0, 0));
        Instantiate(UpStone, OBjPos2, Quaternion.Euler(0, 0, 0));
    }
}
