using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRamp : MonoBehaviour
{
    public float smoothTime = 0.5f; // Smoothing time
    public LayerMask groundLayer; // Layer mask for the ground

    private Vector3 targetPosition; // Target position
    private Vector3 currentVelocity = Vector3.zero; // Velocity for smoothing

    // Start is called before the first frame update
    void Start()
    {
        // Initialize target position
        targetPosition = transform.position;
    }

    void Update()
    {
        // Raycast to find the ground below
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            // Calculate the slope normal
            Vector3 slopeNormal = hit.normal;

            // Smooth the position, considering the slope
            SmoothDownRamp(slopeNormal);
        }
    }

    void SmoothDownRamp(Vector3 slopeNormal)
    {
        // Project the movement onto the slope normal to get the correct movement direction
        Vector3 moveDirection = Vector3.ProjectOnPlane(targetPosition - transform.position, slopeNormal);

        // Smooth the position
        transform.position = Vector3.SmoothDamp(transform.position, transform.position + moveDirection, ref currentVelocity, smoothTime);
    }
}
