using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public HingeJoint hinge;
    public Transform door1;
    public Transform door2;
    public float maxHingeAngle = 45f; // Adjust the angle as needed
    public float doorSeparationDistance = 2f;
    public float doorOpenSpeed = 2.0f; // Adjust the speed as needed
    private bool doorsOpened = false;
    private Vector3 door1TargetPosition;
    private Vector3 door2TargetPosition;

    void Start()
    {
        // Calculate the target positions for the doors
        door1TargetPosition = door1.position + Vector3.forward * doorSeparationDistance / 2f;
        door2TargetPosition = door2.position - Vector3.forward * doorSeparationDistance / 2f;
    }

    void Update()
    {
        // Get the hinge's angle in degrees
        float hingeAngle = hinge.angle;

        // Check if the hinge angle is greater than or equal to the specified angle (fully open)
        if (hingeAngle >= maxHingeAngle && !doorsOpened)
        {
            // Move the doors towards their target positions gradually
            door1.position = Vector3.MoveTowards(door1.position, door1TargetPosition, Time.deltaTime * doorOpenSpeed);
            door2.position = Vector3.MoveTowards(door2.position, door2TargetPosition, Time.deltaTime * doorOpenSpeed);

            // Check if the doors are within a small range of their target positions
            if (Vector3.Distance(door1.position, door1TargetPosition) <= 0.1f && Vector3.Distance(door2.position, door2TargetPosition) <= 0.1f)
            {
                // Prevent the doors from moving again
                doorsOpened = true;
            }
        }
        if (doorsOpened && door1 && door2)
        {
            Destroy(door1.gameObject);
            Destroy(door2.gameObject);
        }
    }
}
