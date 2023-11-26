using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CollectKeyMaze : XRGrabInteractable
{
    private bool isCollected = false;
    public float displayTime = 3f;

    public Canvas keyCanvas;
    public TextMeshProUGUI keyText;

    // Create a separate MonoBehaviour to run coroutines
    private CoroutineRunner coroutineRunner;

    protected override void OnEnable()
    {
        base.OnEnable();
        onSelectEntered.AddListener(OnGrab);

        // Create the CoroutineRunner
        coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        if (!isCollected)
        {
            isCollected = true;

            // Hide the key
            gameObject.SetActive(false);

            // Show the "Key collected" text
            keyText.text = "Key collected";
            keyCanvas.enabled = true;

            // Start the coroutine on the CoroutineRunner
            coroutineRunner.StartCoroutine(HideTextCoroutine());
        }
    }

    private class CoroutineRunner : MonoBehaviour { }

    private System.Collections.IEnumerator HideTextCoroutine()
    {
        yield return new WaitForSeconds(displayTime);

        // Hide the text after displayTime seconds
        keyCanvas.enabled = false;
    }
}
