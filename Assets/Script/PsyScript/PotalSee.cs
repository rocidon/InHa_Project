using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalSee : MonoBehaviour
{
    public Transform player;
    public float activationDistance = 5f;
    private Renderer portalRenderer;

    private void Start()
    {
        portalRenderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= activationDistance)
        {
            portalRenderer.enabled = true;
        }
        else
        {
            portalRenderer.enabled = false;
        }
    }
}

