using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ��, Ŭ�����.
public class TestAdjustment : MonoBehaviour
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
