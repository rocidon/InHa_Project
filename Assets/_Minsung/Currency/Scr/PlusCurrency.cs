using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlusCurrency : MonoBehaviour
{
    public CurrencyData currencyData;
    public void OnClickPlusGold()
    {

        //오브젝트 충돌시,
        currencyData.testgoldAmount += 100;
        Debug.Log("+100 Gold");
    }
    public void OnClickPlusBone()
    {
        currencyData.testboneAmount += 100;
        Debug.Log("+100 Bone");
    }
}
