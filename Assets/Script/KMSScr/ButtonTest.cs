using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public Button button;

    // 버튼 색 변경 함수
    void changeColor()
    {
        ColorBlock colorBlock = button.colors;

        //(r, g, b, a) 기준 빨간색으로 normal Color 지정
        colorBlock.normalColor = new Color(0f, 0f, 0f, 1f);

        button.colors = colorBlock;
    }
}

