using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CollectKeyMaze : XRGrabInteractable {
    private bool isCollected = false;
    public float displayTime = 3f;

    public Canvas keyCanvas;
    public TextMeshProUGUI keyText;

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

            // Set the position of the canvas in front of the player
            keyCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1;

            // Make the canvas look at the player's camera
            keyCanvas.transform.LookAt(Camera.main.transform.position);
            keyCanvas.transform.Rotate(0, 180, 0);

            keyText.text = "Key collected";
            keyCanvas.enabled = true;

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