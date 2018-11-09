using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject pauseScreen;
    private bool gamePaused = false;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused)
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
        Debug.Log("Restarting ");
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

    private void OnApplicationPause(bool pause)
    {
        //maybe we want do something here
    }



}
