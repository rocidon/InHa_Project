using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurCurrency : MonoBehaviour
{

    public CurrencyData currencyData;
    // Start is called before the first frame update
    void Awake()
    {
        currencyData.curSilverAmount = 0;
        currencyData.curGoldAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
