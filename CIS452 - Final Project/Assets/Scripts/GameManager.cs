/*
* Levi Schoof
* GameManager.cs
* Final Project
* Handels the losing of the game and the restarting of game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject losePanel;
    private PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        losePanel.SetActive(false);
        pauseManager = FindObjectOfType<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseManager.gameLost && Input.GetKeyDown(KeyCode.R) && losePanel.activeSelf)
        {
            ResartGame();
        }
    }

    public void PlayerDied()
    {
        StartCoroutine(FadeInLoseScrean());
    }

    private void ResartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator FadeInLoseScrean()
    {
        pauseManager.gameLost = true;
        losePanel.SetActive(true);
        Color tempColor = losePanel.transform.GetComponentInChildren<Image>().color;
        Color textColor = new Color();
        TextMeshProUGUI[] texts = losePanel.transform.GetChild(0).transform.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
        {
            textColor = text.color;
            textColor.a = 0;
            text.color = textColor;
        }
        tempColor.a = 0;
        losePanel.transform.GetComponentInChildren<Image>().color = tempColor;

        while(tempColor.a < 1)
        {
            tempColor.a += .05f;
            textColor.a += .05f;

            losePanel.transform.GetComponentInChildren<Image>().color = tempColor;
            foreach (TextMeshProUGUI text in texts)
            {
                text.color = textColor;
            }
            yield return new WaitForSeconds(.09f);
        }
        yield return new WaitForSeconds(0);
        Time.timeScale = 0;
    }
}
