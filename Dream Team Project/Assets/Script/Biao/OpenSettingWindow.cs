using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingWindow : MonoBehaviour {
    public GameObject settingsWindow;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }
}
