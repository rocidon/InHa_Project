using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public CurrencyData currencyData;
    public void OnClickPlusGold()
    {
        currencyData.goldAmount += 100;
        Debug.Log("+100 Gold");
    }
    public void OnClickPlusBone()
    {
        currencyData.boneAmount += 100;
        Debug.Log("+100 Bone");
    }
}
