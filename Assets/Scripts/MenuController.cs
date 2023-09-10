using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas sceneListCanvas;
    public Canvas guideCanvas;

    public void ShowScenesCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        sceneListCanvas.gameObject.SetActive(true);
    }

    public void ShowGuideCanvas()
    {   
        mainCanvas.gameObject.SetActive(false);
        guideCanvas.gameObject.SetActive(true);
    }

    public void GoBack()
    {
        sceneListCanvas.gameObject.SetActive(false);
        guideCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void LoadOfficeLevel()
    {
        SceneManager.LoadScene("OfficeLevel");
    }

    public void LoadWarehouseLevel()
    {
        SceneManager.LoadScene("WarehouseLevel");
    }

    public void LoadBasementLevel()
    {
        SceneManager.LoadScene("BasementLevel");
    }

    public void LoadMazeLevel()
    {
        SceneManager.LoadScene("MazeLevel");
    }
}
