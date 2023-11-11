using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeControl : MonoBehaviour
{
    public float maxSlopeAngle = 45.0f; // Adjust this value as needed
    public float moveSpeed = 5.0f; // Adjust the movement speed
    public float slopeSmoothness = 5.0f; // Adjust the smoothing factor

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleSlope();
    }

    private void HandleSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, characterController.height / 2 + 0.1f))
        {
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            if (slopeAngle <= maxSlopeAngle)
            {
                // Calculate the desired movement direction based on the slope
                Vector3 slopeDirection = Vector3.Cross(Vector3.up, hit.normal);
                Vector3 moveDirection = slopeDirection * moveSpeed;

                // Smoothly interpolate the character's position to follow the slope
                Vector3 newPosition = Vector3.Lerp(transform.position, transform.position + moveDirection, slopeSmoothness * Time.deltaTime);
                characterController.Move(newPosition - transform.position);
            }
        }
    }
}
