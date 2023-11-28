using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountKeysMaze : MonoBehaviour
{
    public TextMeshProUGUI keyCountText; // Reference to your TextMeshPro object
    int activeKeyCount;

    void Update()
    {
        activeKeyCount = CountActiveKeys();
        UpdateKeyCountText();
    }

    int CountActiveKeys()
    {
        GameObject[] propsKeyObjects = GameObject.FindGameObjectsWithTag("Collectible");

        int activeKeys = 0;

        foreach (GameObject keyObject in propsKeyObjects)
        {
            if (keyObject.activeSelf)
            {
                activeKeys++;
            }
        }

        return activeKeys;
    }

    void UpdateKeyCountText()
    {
        // Update the TextMeshPro text with the count of active keys
        if (activeKeyCount != 0)
        {
            keyCountText.text = "Keys Left: " + activeKeyCount;
        } else {
            keyCountText.text = "Head to The Exit";
        }
    }
}
