using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public Button button;

    // ��ư �� ���� �Լ�
    void changeColor()
    {
        ColorBlock colorBlock = button.colors;

        //(r, g, b, a) ���� ���������� normal Color ����
        colorBlock.normalColor = new Color(0f, 0f, 0f, 1f);

        button.colors = colorBlock;
    }
}

