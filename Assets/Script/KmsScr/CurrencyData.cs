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

    private void OnEnable()
    {
        Initialize();
    }
    private void Initialize()
    {
        silverAmount = 0;
        goldAmount = 0;
        curSilverAmount = 0;
        curGoldAmount = 0;
    }
}