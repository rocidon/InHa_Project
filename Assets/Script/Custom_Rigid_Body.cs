using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Rigid_Body : MonoBehaviour
{
    public bool Is_Gravity;
    public float Mass;

    float Timer;
    float Gravity;
    float Falling_Time;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
        Gravity = 0f;
        Falling_Time = 0f;
        if (Is_Gravity)
        {
            Mass = Mass > 0f ? Mass : 0f;
            Gravity = 9.8f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > 0.001f)
        {
            CustomUPdate();
            Timer = 0f;
        }
    }
    //position set
    void CustomUPdate()
    {

        //Debug.Log(Gravity_force);
        float G = Mathf.Log(Mass+0.1f, Falling_Time);
        transform.Translate(Vector3.down * G);//юс╫ц
        Debug.Log(G);
        Falling_Time++;
    }
}
