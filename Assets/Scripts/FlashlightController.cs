using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
    }

    public void ToggleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
    }
}
