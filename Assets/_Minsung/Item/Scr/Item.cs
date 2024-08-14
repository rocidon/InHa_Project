using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;
    public float attackPower;
    public float durability;
}
