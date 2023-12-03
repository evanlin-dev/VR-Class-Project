using System.Collections;
using UnityEngine;
using TMPro;

public class LightController : MonoBehaviour
{
    public GameObject[] hingeObjects;
    public GameObject lightsToEnable;
    public GameObject sunToEnable;
    public GameObject otherLights;
    public Material skyboxMaterial1;
    public Material skyboxMaterial2;

    public TextMeshProUGUI counterText;
    public float angleThreshold = 45f;

    private bool[] leverCounted;
    private int counter = 0;

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
                if (Mathf.Abs(hingeJoint.angle) > angleThreshold)
                {
                    counter++;
                    leverCounted[i] = true;
                }
            }
        }

        if (counter >= 1)
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
        if (counterText != null)
        {
            counterText.text = "Counter: " + counter.ToString() + "/3";
        }
        else
        {
            Debug.LogWarning("CounterText is not assigned in the inspector.");
        }
    }
}
