/*
* William Nomikos
* PauseManager.cs
* Assignment 9
* Handles pause menu functionality, including pausing the game,
* unpausing the game, restarting the game, and quitting to the 
* main menu. Also handles game music and button sound effects.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool paused;
    public bool gameLost;

    public GameObject PauseCanvas;

    public AudioSource GameSource;
    public AudioClip gameMusic;

    public AudioSource SoundEffectSource;
    public AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameLost = false;

        paused = false;
        PauseCanvas.SetActive(false);

        GameSource.clip = gameMusic;
        GameSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameLost)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (paused == false)
        {
            paused = true;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
        else if (paused == true)
        {
            Time.timeScale = 1;
            paused = false;
            PauseCanvas.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonClick()
    {
        SoundEffectSource.clip = buttonClick;
        SoundEffectSource.Play();
    }
}
