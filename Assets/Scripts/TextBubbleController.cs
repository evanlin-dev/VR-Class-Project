using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class TextBubbleController : MonoBehaviour
{
    public GameObject character; // Reference to your character GameObject
    public Vector3 offset = new Vector3(0f, 0f, 0f); // Adjust the offset to position the bubble correctly

    private string textContent = "I've been expecting you, Mr. Anderson. We have much to speak about."; // Default text content, you can change this in the Unity Editor

    // Reference to the TextMeshPro component
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro.text = textContent;
    }

    void Update()
    {
        // Ensure the character reference is not null
        if (character != null)
        {
            // Set the position of the Canvas above the character
            transform.position = character.transform.position + offset;

            // Make the Canvas face the camera
            transform.LookAt(Camera.main.transform);
        }

        // You may want to add logic to show/hide the bubble based on certain conditions
    }
}
