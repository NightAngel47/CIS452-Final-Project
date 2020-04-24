using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Levi Schoof
* MainMenu.cs
* Final Project
* Handels the UI functions in the Main Menu
*/

public class MainMenu : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
