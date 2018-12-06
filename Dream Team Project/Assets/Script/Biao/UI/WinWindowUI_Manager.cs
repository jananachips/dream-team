using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindowUI_Manager : MonoBehaviour {
    public string winText = "You Win";

    public GameObject nextLevel_Button;
    public GameObject restartLevel_Button;
    public GameObject returnMainMenu_Button;

    public AllWindowsUI_Manager allWindowUI_Manager;

	void Awake () {
	}

    private void OnEnable()
    {
        allWindowUI_Manager = FindObjectOfType<AllWindowsUI_Manager>();
        allWindowUI_Manager.SetUITextAs(winText);

        allWindowUI_Manager.EnableUIText();
        allWindowUI_Manager.EnableUIBackground(1f);

        nextLevel_Button.SetActive(true);
        restartLevel_Button.SetActive(true);
        returnMainMenu_Button.SetActive(true);
    }

    //unlike pause window, this is not necessary, but just in case
    private void OnDisable()
    {
        allWindowUI_Manager.DisableUIText();
        allWindowUI_Manager.DisableUIBackground();

        //nextLevel_Button.SetActive(false);
        restartLevel_Button.SetActive(false);
        returnMainMenu_Button.SetActive(false);
    }

    void Update () {
		
	}
}
