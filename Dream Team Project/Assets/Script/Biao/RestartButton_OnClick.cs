using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton_OnClick : MonoBehaviour {
    public GameManager gameManager;
    public Button myButton;

	void Start () {
        myButton = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();
        myButton.onClick.AddListener(gameManager.RestartGame);
	}

	void Update () {
		
	}
}
