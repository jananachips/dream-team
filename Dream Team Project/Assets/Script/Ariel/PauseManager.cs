using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

	public GameObject pauseUI;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseHandler();
		}
	}

	public void PauseHandler()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			pauseUI.SetActive(true);
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			pauseUI.SetActive(false);
		}
	}
}
