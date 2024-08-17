using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//정산 즉, 클리어시.
public class TestAdjustment : MonoBehaviour
{
    public CurrencyData test;

    public void OnClickAdjustment()
    {
        test.boneAmount += test.testboneAmount;
        test.goldAmount += test.testgoldAmount;

        test.testboneAmount = 0;
        test.testgoldAmount = 0;
    }

}
