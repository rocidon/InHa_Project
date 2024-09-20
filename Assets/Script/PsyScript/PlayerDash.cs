using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 3f; // 대쉬 거리
    public float dashCooldown = 5f; // 대쉬 쿨타임
    private bool canDash = true; // 대쉬 가능 여부

    void Update()
    {
        // 대쉬 키 입력 처리
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash();
        }
    }

    void Dash()
    {
        // 대쉬 실행
        Vector3 dashDirection = transform.forward * dashDistance;
        transform.position += dashDirection;

        // 대쉬 쿨타임 시작
        canDash = false;
        Invoke("ResetDash", dashCooldown);
    }

    void ResetDash()
    {
        canDash = true;
    }
}

