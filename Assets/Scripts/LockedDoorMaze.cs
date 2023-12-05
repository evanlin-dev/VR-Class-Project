using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorMaze : MonoBehaviour
{
    public bool isOpen = false;
    public bool canActivate;
    public float activationRange = 2f; // if player distance < activationRange then open door

    public AudioClip openDoor;
    public AudioClip closeDoor;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        openDoor = Resources.Load<AudioClip>("open");
        closeDoor = Resources.Load<AudioClip>("close");
        source.volume = 0.3f;
        canActivate = CountActiveKeys() == 0;
    }


    void Update()
    {
        canActivate = CountActiveKeys() == 0;
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
            transform.Rotate(Vector3.up, -90);
            isOpen = true;
            source.clip = openDoor;
            source.Play();
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

    int CountActiveKeys()
    {
        GameObject[] propsKeyObjects = GameObject.FindGameObjectsWithTag("Collectible");

        int activeKeys = 0;

        foreach (GameObject keyObject in propsKeyObjects)
        {
            if (keyObject.activeSelf)
            {
                activeKeys++;
            }
        }

        return activeKeys;
    }
}