using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame_Button : MonoBehaviour {

    //start game window is too simple, so it doesn't have a manager, button will do everything
    public GameManager gameManager;
    public AllWindowsUI_Manager allWindowsUI_Manager;
    public TextBlinking_Manager textBlinking_Manager;


	void Start () {
        DoInitials();
	}

    private void OnEnable()
    {
        DoInitials();
    }

    private void DoInitials()
    {
        gameManager = FindObjectOfType<GameManager>();
        allWindowsUI_Manager = FindObjectOfType<AllWindowsUI_Manager>();
        textBlinking_Manager = FindObjectOfType<TextBlinking_Manager>();
        allWindowsUI_Manager.EnableUIBackground();
        allWindowsUI_Manager.EnableUIText();
        allWindowsUI_Manager.SetUITextAs("Press Button To Start Game");
        gameManager.PauseTimeScale();
        gameManager.StopHotKeys();
        textBlinking_Manager.DoTextBlinking();
    }

    private void OnDisable()
    {
        StartGameButton();
    }

    public void StartGameButton()
    {
        //stop or reset all kinds of things
        textBlinking_Manager.StopTextBlinking();
        allWindowsUI_Manager.DisableUIBackground();
        allWindowsUI_Manager.DisableUIText();
        gameObject.SetActive(false);
        gameManager.ResetTimeScale();
        gameManager.ResumeHotKeys();
    }

}
