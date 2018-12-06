using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton_OnClick : MonoBehaviour {
    public Button myButton;
    public GameObject settingsWindowManager;

	void Start () {
        myButton = GetComponent<Button>();		
        myButton.onClick.AddListener(OpenSettingsUI);
	}
	

    private void OpenSettingsUI()
    {
        settingsWindowManager.SetActive(true);
    }
}
