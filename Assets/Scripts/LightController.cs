using System.Collections;
using UnityEngine;
using TMPro;

public class LightController : MonoBehaviour
{
    public GameObject[] hingeObjects; // List of game objects with hinge joints
    public GameObject lightsToEnable; // Lights to enable
    public GameObject sunToEnable;    // Sun to enable
    public GameObject otherLights;
    public Material skyboxMaterial1;   // Skybox material to switch to when the counter reaches a certain value
    public Material skyboxMaterial2;   // Another Skybox material

    public TextMeshProUGUI counterText;
    public float angleThreshold = 45f; // Angle threshold to trigger the counter

    private bool[] leverCounted; // Array to keep track of whether each lever has been counted
    private int counter = 0; // Counter to keep track of the number of objects exceeding the angle

    private void Start()
    {
        sunToEnable.SetActive(false);
        lightsToEnable.SetActive(false);
        otherLights.SetActive(false);
        RenderSettings.skybox = skyboxMaterial2;
        InitializeLeverCount();
    }

    private void Update()
    {
        CheckHingeAngles();
        UpdateCounterText();
    }

    private void InitializeLeverCount()
    {
        leverCounted = new bool[hingeObjects.Length];
        for (int i = 0; i < leverCounted.Length; i++)
        {
            leverCounted[i] = false;
        }
    }

    private void CheckHingeAngles()
    {
        for (int i = 0; i < hingeObjects.Length; i++)
        {
            GameObject hingeObject = hingeObjects[i];
            HingeJoint hingeJoint = hingeObject.GetComponent<HingeJoint>();

            if (hingeJoint != null && !leverCounted[i])
            {
                // Check if the hinge angle exceeds the threshold
                if (Mathf.Abs(hingeJoint.angle) > angleThreshold)
                {
                    counter++;
                    leverCounted[i] = true; // Mark the lever as counted
                }
            }
        }

        // Check if the counter reaches a certain amount
        if (counter >= 1) // Adjust the number as per your requirement
        {
            EnableLightsAndSun();
            ChangeSkybox();
        }
    }

    private void EnableLightsAndSun()
    {
        lightsToEnable.SetActive(true);
        sunToEnable.SetActive(true);
        otherLights.SetActive(true);
    }

    private void ChangeSkybox()
    {
        if (counter >= 1)
        {
            RenderSettings.skybox = skyboxMaterial1;
        }
    }

    private void UpdateCounterText()
    {
        // Check if the Text component is assigned
        if (counterText != null)
        {
            // Update the text with the current counter value
            counterText.text = "Counter: " + counter.ToString() + "/3";
        }
        else
        {
            Debug.LogWarning("CounterText is not assigned in the inspector.");
        }
    }
}
