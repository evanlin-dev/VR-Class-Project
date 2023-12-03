using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverController : MonoBehaviour
{
    public HingeJoint hinge;
    public Transform door1;
    public Transform door2;
    public float maxHingeAngle = 45f;
    public float doorSeparationDistance = 2f;
    public float doorOpenSpeed = 2.0f;
    private bool doorsOpened = false;
    private Vector3 door1TargetPosition;
    private Vector3 door2TargetPosition;

    public AudioClip leverSound;
    private AudioSource audioSource;
    private bool playedSound;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        playedSound = false;
        grabInteractable = GetComponent<XRGrabInteractable>();
        door1TargetPosition = door1.position + Vector3.forward * doorSeparationDistance / 2f;
        door2TargetPosition = door2.position - Vector3.forward * doorSeparationDistance / 2f;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = leverSound;
    }

    void Update()
    {
        float hingeAngle = hinge.angle;

        if (hingeAngle >= maxHingeAngle && !doorsOpened)
        {
            if (!playedSound)
            {
                audioSource.PlayOneShot(leverSound);
                playedSound = true;
            }
            door1.position = Vector3.MoveTowards(door1.position, door1TargetPosition, Time.deltaTime * doorOpenSpeed);
            door2.position = Vector3.MoveTowards(door2.position, door2TargetPosition, Time.deltaTime * doorOpenSpeed);

            if (Vector3.Distance(door1.position, door1TargetPosition) <= 0.1f && Vector3.Distance(door2.position, door2TargetPosition) <= 0.1f)
            {
                doorsOpened = true;
                if (grabInteractable != null)
                {
                    grabInteractable.enabled = false;
                }
            }
        }
        if (doorsOpened && door1 && door2)
        {
            Destroy(door1.gameObject);
            Destroy(door2.gameObject);
        }
    }
}
