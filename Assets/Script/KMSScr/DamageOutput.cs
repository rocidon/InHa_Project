using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class DamageOutput : MonoBehaviour
{
    TextMeshPro textMP;

    public float textUpSpeed;
    public float alphaSpeed;
    public float destoryTime;

    public int damage;

    void Start()
    {
        textMP = GetComponent<TextMeshPro>();
        textMP.text = damage.ToString();

        Invoke("DestoryDamageText", destoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, textUpSpeed * Time.deltaTime, 0)); 
        textMP.color = new Color(1f, 0, 0, Mathf.Lerp(textMP.color.a, 0, Time.deltaTime * alphaSpeed));
    }

    private void DestoryDamageText()
    {
        Destroy(gameObject);
    }
}
