using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLvButton_OnClick : MonoBehaviour {

    public Button nextLvButton;
    public GameManager gameManager;

	void Start () {
        nextLvButton = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();

        nextLvButton.onClick.AddListener(gameManager.LoadNextLevel);


	}
	
	void Update () {
		
	}
}
