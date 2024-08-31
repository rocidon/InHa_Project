using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image image;

    private WeaponData _item;
    public WeaponData item
    {
        //슬릇의 item 정보를 넘겨줄 때 사용
        get { return _item; }
        set
        {
            //item에 들어오는 정보의 값은 _item에 저장
            _item = value;
            if (_item != null)
            {
                //Inventory.cs안에 List<WeaponData> items 등록된 아이템이 있다면
                image.sprite = item.itemImage;

                //이미지 표시
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {

                //이미지 표시 x
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
