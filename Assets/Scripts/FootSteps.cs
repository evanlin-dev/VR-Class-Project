using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip steps;
    private AudioSource source;
    private Vector3 lastPosition;
    public float minDistance = 0.01f; // minimum distance to trigger a footstep
    public float footstepInterval = 0.5f; // interval between footstep sounds

    private float timeSinceLastFootstep;

    void Start()
    {
        source = GetComponent<AudioSource>();
        steps = Resources.Load<AudioClip>("footSteps");
        source.clip = steps;
        source.volume = 1.2f;
        lastPosition = transform.position;
    }

    void Update()
    {
        // check if the camera moved
        if (Vector3.Distance(transform.position, lastPosition) >= minDistance)
        {
            // check if enough time has passed
            if (Time.time - timeSinceLastFootstep >= footstepInterval)
            {
                source.Play();
                timeSinceLastFootstep = Time.time; // update the time of the last footstep
            }
        }

        lastPosition = transform.position;
    }
}
