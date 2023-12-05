using UnityEngine;
using TMPro;

public class TextBubbleController : MonoBehaviour
{
    public GameObject character;
    public Vector3 offset = new Vector3(0f, 2f, 0f);
    public Canvas canvas;
    private int counter = 0;
    private string textContent;
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        textContent = textUpdate();
        textMeshPro.text = textContent;

        // Invoke the method to increment counter every 8 seconds
        InvokeRepeating("IncrementCounter", 0f, 7f);
    }

    void Update()
    {
        // Set the position of the Canvas above the character
        canvas.transform.position = character.transform.position + offset;
        canvas.transform.LookAt(Camera.main.transform);
    }

    void IncrementCounter()
    {
        // Increment the counter and update the text content
        counter++;
        textContent = textUpdate();
        textMeshPro.text = textContent;

        // Stop invoking when the counter reaches the maximum value
        if (counter > 5)
        {
            counter = 0;
        }
    }

    string textUpdate()
    {
        switch (counter)
        {
            case 0:
                return "Finally, you're here. Took long enough, you're three hours late!";
            case 1:
                return "Management told me to prep you on what you'll be doing today";
            case 2:
                return "It's real simple. You see that key on my desk, the one that's glowing?";
            case 3:
                return "All you gotta do is find the other 8 identical keys spread around this office";
            case 4:
                return "Once you do that, we'll finally be able to unlock the basement";
            case 5:
                return "Good luck, and try not to get lost. This place can be very confusing to navigate around";
            default:
                return "";
        }
    }
}


/*
Write a function that increments counter when the character is grabbed
The character should not move after being grabbed, he should always be stationary
Call the newly written function within update
*/