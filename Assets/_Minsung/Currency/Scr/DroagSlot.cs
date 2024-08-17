using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class DroagSlot : MonoBehaviour
{
    [HideInInspector] public Slot curSlot;
    [SerializeReference] private Image mItemImage;

    public void DragSetImage(Image _itemImage)
    {
        mItemImage.sprite = _itemImage.sprite;
        SetColor(1);
    }

    public void SetColor(float alpha)
    {
        Color color = mItemImage.color;
        color.a = alpha;
        mItemImage.color = color;
    }
}
