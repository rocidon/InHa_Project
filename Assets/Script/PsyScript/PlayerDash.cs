using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 3f; // �뽬 �Ÿ�
    public float dashCooldown = 5f; // �뽬 ��Ÿ��
    private bool canDash = true; // �뽬 ���� ����

    void Update()
    {
        // �뽬 Ű �Է� ó��
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash();
        }
    }

    void Dash()
    {
        // �뽬 ����
        Vector3 dashDirection = transform.forward * dashDistance;
        transform.position += dashDirection;

        // �뽬 ��Ÿ�� ����
        canDash = false;
        Invoke("ResetDash", dashCooldown);
    }

    void ResetDash()
    {
        canDash = true;
    }
}

