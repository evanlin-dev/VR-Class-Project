using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorMaze : MonoBehaviour
{
    public bool isOpen = false;
    public bool canActivate = true;
    public float activationRange = 2f; // if player distance < activationRange then open door

    public AudioClip openDoor;
    public AudioClip closeDoor;
    private AudioSource source;
    private static OpenDoorMaze currentlyPlayingDoor; // static variable to keep track of the currently playing door
    void Start()
    {
        source = GetComponent<AudioSource>();
        openDoor = Resources.Load<AudioClip>("open");
        closeDoor = Resources.Load<AudioClip>("close");
        source.volume = 0.3f;
    }


    void Update()
    {
        if (canActivate) // checks if door has permission to be opened
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
            if (currentlyPlayingDoor != null && currentlyPlayingDoor != this) // stops two doors from playing sound at the same time
            {
                currentlyPlayingDoor.source.Stop();
            }
            transform.Rotate(Vector3.up, -90);
            isOpen = true;
            source.clip = openDoor;
            source.Play();
            currentlyPlayingDoor = this;
        }
    }

    void CloseDoor()
    {
        if (isOpen)
        {
            transform.Rotate(Vector3.up, 90);
            isOpen = false;
            source.clip = closeDoor;
            source.Play();
        }
    }
}