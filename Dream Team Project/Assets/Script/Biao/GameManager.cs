using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//control the main game mechanism: restart, pause, all kinds of windows(settings window), etc
//and keep listening to the keyboard for the major input: escape key, maybe something else later

public class GameManager : MonoBehaviour {

    public GameObject pauseScreen;
    public GameObject settingsWindow;
    public int MainMenuIndex = 0;

    private bool gamePaused = false;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (settingsWindow.activeSelf)
            {
                //if settingswindow is active, close it first
                settingsWindow.SetActive(false);
            }
            else if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }else if (!gamePaused && Input.GetKeyDown(KeyCode.P))
        {
            RestartGame();
        }
    }

    //to use this in other code:  FindObjectOfType<GameManager>().RestartGame()
    public void RestartGame()
    {
        //build index: when we build the game, from top to bottom, start from 0
        //Debug.Log("Restarting ");
        if (gamePaused)
        {
            ResumeGame();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void PauseGame()
    {
        //freeze time
        Time.timeScale = 0f;
        gamePaused = true;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        pauseScreen.SetActive(false);
    }

    public bool IsPause()
    {
        return gamePaused;
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuIndex);        
    }



}
