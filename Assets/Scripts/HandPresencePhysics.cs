using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;
    private bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        if (!isGrabbed)
        {
            foreach (var item in handColliders)
            {
                item.enabled = true;
            }
        }
    }

    public void EnableHandColliderDelay(float delay)
    {
        isGrabbed = false;
        Invoke("EnableHandCollider", delay);
    }

    public void DisableHandCollider()
    {
        isGrabbed = true;
        foreach(var item in handColliders)
        {
            item.enabled = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);
        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;
        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
