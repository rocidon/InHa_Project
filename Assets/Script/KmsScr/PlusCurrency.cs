using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlusCurrency : MonoBehaviour
{
    public CurrencyData currencyData;
    public void OnClickPlusGold()
    {
        currencyData.curGoldAmount += 100;
        Debug.Log("+100 Gold");
    }
    public void OnClickPlusBone()
    {
        currencyData.curSilverAmount += 100;
        Debug.Log("+100 Bone");
    }
}
