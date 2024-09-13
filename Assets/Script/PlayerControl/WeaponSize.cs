using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private void LateUpdate()
    {
       /* transform.position += new Vector3(0, 4, 0);*/
        transform.localScale += new Vector3(0, 1.5f, 0);
    }
    // Update is called once per frame
}
