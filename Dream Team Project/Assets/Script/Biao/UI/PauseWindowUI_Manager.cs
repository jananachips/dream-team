using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindowUI_Manager : MonoBehaviour {

    public string pauseText = "Game Paused";

    public GameObject settings_Button;
    public GameObject mute_Button;
    public GameObject restart_Button;
    public GameObject returnMainMenu_Button;

    public AllWindowsUI_Manager allWindowsUI_Manager;


	void Awake () {
        allWindowsUI_Manager = FindObjectOfType<AllWindowsUI_Manager>();
        Debug.Log("pause window start");
	}
	

    private void OnEnable()
    {
        allWindowsUI_Manager.SetUITextAs(pauseText);
        allWindowsUI_Manager.EnableUIText();
        allWindowsUI_Manager.EnableUIBackground();

        settings_Button.SetActive(true);
        mute_Button.SetActive(true);
        restart_Button.SetActive(true);
        returnMainMenu_Button.SetActive(true);

        Debug.Log("pause enabled");
    }

    private void OnDisable()
    {
        settings_Button.SetActive(false);
        mute_Button.SetActive(false);
        restart_Button.SetActive(false);
        returnMainMenu_Button.SetActive(false);

        allWindowsUI_Manager.DisableUIBackground();
        allWindowsUI_Manager.DisableUIText();
    }

}
