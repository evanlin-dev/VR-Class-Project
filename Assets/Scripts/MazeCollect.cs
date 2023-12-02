using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MazeCollect : MonoBehaviour
{
    public string collectibleTag = "Collectible";
    public string promptText = "Do you want to collect this item?";

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onActivate.AddListener(OnItemGrabbed);
    }

    private void OnItemGrabbed(XRBaseInteractor interactor)
    {
        XRDirectInteractor directInteractor = interactor as XRDirectInteractor;
        if (directInteractor != null)
        {
            DisplayPrompt();
        }
    }

    void DisplayPrompt()
    {
        Debug.Log(promptText);
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.green, 2f); // Add this line for debugging ray direction

        // Implement your specific logic for the collection process
        // For example, you could disable the collectible item, update a score, etc.
    }
}
