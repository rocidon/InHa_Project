using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;

    public float attackPower;
    public float durability;
}