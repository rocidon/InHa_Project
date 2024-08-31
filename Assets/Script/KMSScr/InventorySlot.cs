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
        //������ item ������ �Ѱ��� �� ���
        get { return _item; }
        set
        {
            //item�� ������ ������ ���� _item�� ����
            _item = value;
            if (_item != null)
            {
                //Inventory.cs�ȿ� List<WeaponData> items ��ϵ� �������� �ִٸ�
                image.sprite = item.itemImage;

                //�̹��� ǥ��
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {

                //�̹��� ǥ�� x
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
