using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Rigid_Body : MonoBehaviour
{
    public bool Is_Gravity;
    public float Mass;

    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
        if (Is_Gravity)
        {
            Mass = Mass > 0f ? Mass : 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime; ;
        if(Timer > 0.01f)
        {
            if (Is_Gravity)
            {
                transform.Translate(Vector3.down * Time.deltaTime * Mass);//юс╫ц
            }
            Timer = 0f;
        }
    }
}
