using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public GameObject itemToActivate;
    public float activationDelay = 3.0f; // Adjust the delay as needed in seconds
    private float timer = 0.0f;
    private bool itemActivated = false;

    void Update()
    {
        // Check if the item hasn't been activated and the timer hasn't reached the activationDelay
        if (!itemActivated && timer < activationDelay)
        {
            timer += Time.deltaTime; // Increase the timer based on real time
        }
        else if (!itemActivated)
        {
            // Activate the item and mark it as activated
            itemToActivate.SetActive(true);
            itemActivated = true;
        }
    }
}
