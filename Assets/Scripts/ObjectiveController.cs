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
    public AudioSource audioSource;
    public GameObject[] arrows;

    public TextMeshProUGUI counterText;
    public float angleThreshold = 55f;

    public GameObject[] monster;

    private bool[] leverCounted;
    private int lastActivatedLeverIndex = -1;
    private int counter = 0;

    private void Start()
    {
        audioSource.gameObject.SetActive(false);
        for (int i = 0; i < monster.Length; i++)
        {
            monster[i].SetActive(false);
        }
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
                    arrows[i].SetActive(false);

                    audioSource.gameObject.SetActive(true);

                    audioSource.PlayOneShot(leverSound);

                    XRGrabInteractable grabInteractable = hingeObject.GetComponent<XRGrabInteractable>();
                    if (grabInteractable != null)
                    {
                        grabInteractable.enabled = false;
                    }
                    if (counter >= 3)
                    {
                        lastActivatedLeverIndex = i;
                    }
                }
            }
        }

        if (counter >= 3)
        {
            Destroy(door1.gameObject);
            Destroy(door2.gameObject);

            if (lastActivatedLeverIndex >= 0 && lastActivatedLeverIndex < monster.Length)
            {
                monster[lastActivatedLeverIndex].SetActive(true);
            }
        }
    }


    private void UpdateCounterText()
    {
        if (counter >= 3)
        {
            counterText.text = "Escape";
        }
        else if (counterText != null)
        {
            counterText.text = "Counter: " + counter.ToString() + "/3";
        }
        else
        {
            Debug.LogWarning("CounterText is not assigned in the inspector.");
        }
    }
}
