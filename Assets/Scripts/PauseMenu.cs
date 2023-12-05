using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isActive;
    public float distanceFromCamera = 2.0f;
    public float yOffset = 0.0f;

    void Start()
    {
        
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayPauseUI();
    }

    public void DisplayPauseUI()
    {
        if (isActive)
        {
            pauseMenu.SetActive(false);
            isActive = false;
            Time.timeScale = 1;
        }
        else if (!isActive)
        {
            Transform cameraTransform = Camera.main.transform;
            Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera + new Vector3(0, yOffset, 0);
            pauseMenu.transform.position = new Vector3(targetPosition.x, cameraTransform.position.y + yOffset, targetPosition.z);

            pauseMenu.transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);

            pauseMenu.SetActive(true);
            isActive = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
