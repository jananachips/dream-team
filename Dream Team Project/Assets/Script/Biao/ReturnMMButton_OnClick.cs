using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnMMButton_OnClick : MonoBehaviour {

    public GameManager gameManager;
    public Button myButton;

	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(gameManager.LoadMainMenu);
	}
	
	void Update () {
		
	}
}
