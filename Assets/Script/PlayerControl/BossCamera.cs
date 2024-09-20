using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BossCamera : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] Vector3 offset = new Vector3(0, 5f, -10f);

    private void LateUpdate()
    {
        Vector3 newPosition = playerTransform.position + offset;

        transform.position = newPosition;

        transform.LookAt(playerTransform);
    }
}
