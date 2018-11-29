using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//control the main game mechanism: restart, pause, all kinds of windows(settings window), etc
//and keep listening to the keyboard for the major input: escape key, maybe something else later

public class GameManager : MonoBehaviour {


    public GameObject pauseScreen;
    public GameObject settingsWindow;
    public GameObject winnningWindow;
    public GameObject loseWindow;
    //public GameObject startGameWindow;
    public int MainMenuIndex = 0;

    public GameObject[] popOutWindows;


    //public GameObject curActiveWindowUI_Manager;
    //public UIManagerList_Format UIManagersList;


    private bool gamePaused = false;
    private bool stopHotKeys = false;
    void Awake()
    {
        ResetTimeScale();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !stopHotKeys) {
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

    public void StopHotKeys()
    {
        stopHotKeys = true;
    }

    public void ResumeHotKeys()
    {
        stopHotKeys = false;
    }

    public void RestartGame()
    {
        ResetTimeScale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void LoadNextLevel()
    {
        ResetTimeScale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        //freeze time
        PauseTimeScale();
        gamePaused = true;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        ResetTimeScale();
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
        ResetTimeScale();
        SceneManager.LoadScene(MainMenuIndex);        
    }

    public void WinTheGame()
    {
        PauseTimeScale();
        winnningWindow.SetActive(true);
    }

    public void PauseTimeScale(float after = 0.0f)
    {
        StartCoroutine(DoPauseTimeScale(after));
    }

    IEnumerator DoPauseTimeScale(float after_temp)
    {
        yield return new WaitForSecondsRealtime(after_temp);
        //FIXME: later
        Time.timeScale = 0f;
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }

    public void LostTheGame()
    {
        PauseTimeScale();
        loseWindow.SetActive(true);

        //FIXME: doesn't work very well

        //clean up player dialogues
        popOutWindows = GameObject.FindGameObjectsWithTag("MessageBox");
        for(int i = 1; i < popOutWindows.Length; i++)
        {
            popOutWindows[i].SetActive(false);
        }
    }
}
