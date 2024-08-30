using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    [SerializeField]
    public GameObject Stone;
    public float FallingHeight;
    public float MinDis;
    public float MaxDis;
    // Start is called before the first frame update
    void Start()
    {
        FallingHeight = FallingHeight < 8.0f ? 10.0f : FallingHeight;
        MinDis = MinDis < 3.0f ? 3.0f : MinDis;
        MaxDis = MaxDis < 10.0f ? 10.0f : MaxDis;
        //돌들을 일정한 위치에 생성 시킴
        //자신의 기준으로 일정한 간격에 떨어짐
        Vector3 StartPosition= transform.position;
        float Range = Random.Range(MinDis, MaxDis);
        for (int i = 0; i < 4; i++)
        {
            Vector3 OBjPos1 = StartPosition + new Vector3(Range * i + Range, FallingHeight, 0);
            Vector3 OBjPos2 = StartPosition + new Vector3(Range * -i - Range, FallingHeight, 0);
            Instantiate(Stone, OBjPos1, Quaternion.Euler(0,0,0));
            Instantiate(Stone, OBjPos2, Quaternion.Euler(0,0,0));
        }

    }
}
