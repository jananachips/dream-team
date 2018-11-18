using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseWindowUI_Manager : MonoBehaviour {
    public string loseText = "You Lose";

    public AllWindowsUI_Manager allWindowsUI_Manager;
    public GameObject restartButton;
    public GameObject returnMainMenuButton;


	void OnEnable () {
        allWindowsUI_Manager = FindObjectOfType<AllWindowsUI_Manager>();

        restartButton.SetActive(true);
        returnMainMenuButton.SetActive(true);

        allWindowsUI_Manager.SetUITextAs(loseText);
        allWindowsUI_Manager.EnableUIBackground(1f);
        allWindowsUI_Manager.EnableUIText();
	}
	
}
