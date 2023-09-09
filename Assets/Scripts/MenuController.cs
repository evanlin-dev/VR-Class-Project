using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
