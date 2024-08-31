using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//정산 즉, 클리어시.
public class ClearAdjustment : MonoBehaviour
{
    public CurrencyData test;

    public void OnClickAdjustment()
    {
        test.silverAmount += test.curSilverAmount;
        test.goldAmount += test.curGoldAmount;

        test.curSilverAmount = 0;
        test.curGoldAmount = 0;
    }

}


/* //Coin Eat,,, Drag, CurrencyData
     public CurrencyData currencyData;

     currencyData.curSilverAmount += ...;

 */