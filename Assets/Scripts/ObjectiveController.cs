using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectiveController : MonoBehaviour
{
    public GameObject[] hingeObjects;
    public GameObject door1;
    public GameObject door2;

    public AudioClip leverSound;
    private AudioSource audioSource;
    public GameObject[] arrows;

    public TextMeshProUGUI counterText;
    public float angleThreshold = 45f;

    private bool[] leverCounted;
    private int counter = 0;

    private void Start()
    {
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
                    leverCounted[i] = true;
                    arrows[i].SetActive(false);

                    audioSource.PlayOneShot(leverSound);

                    XRGrabInteractable grabInteractable = hingeObject.GetComponent<XRGrabInteractable>();
                    if (grabInteractable != null)
                    {
                        grabInteractable.enabled = false;
                    }
                }
            }
        }

        if (counter >= 3)
        {
            Destroy(door1.gameObject);
            Destroy(door2.gameObject);
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
