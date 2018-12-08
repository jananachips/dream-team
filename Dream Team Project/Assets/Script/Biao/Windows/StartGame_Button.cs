using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame_Button : MonoBehaviour {

    public GameObject startGameWindow;

	void Start () {
        Time.timeScale = 0f;		
	}
	
	void Update () {
		
	}



    public void StartGameButton()
    {
        Time.timeScale = 1f;
        DisableStartWindow();
    }

    private void DisableStartWindow()
    {
        startGameWindow.SetActive(false);
    }
}
