using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorMaze : MonoBehaviour
{
    public bool isOpen = false;
    public bool canActivate = true;
    public float activationRange = 3f; // if player distance < activationRange then open door

    void Update()
    {
        if (canActivate) // Makes sure door isn't already open
        {
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position); // distance between door and player camera

            if (distance < activationRange)
            {
                OpenDoor();
            }
            else if (isOpen)
            {
                CloseDoor();
            }
        }
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            transform.Rotate(Vector3.up, -90);
            isOpen = true;
        }
    }

    void CloseDoor()
    {
        if (isOpen)
        {
            transform.Rotate(Vector3.up, 90);
            isOpen = false;
        }
    }
}