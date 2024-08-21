using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class CurrencyData : ScriptableObject
{
    public Sprite silverImage;
    public Sprite goldImage;

    public int silverAmount;
    public int goldAmount;

    public int curSilverAmount;
    public int curGoldAmount;
}