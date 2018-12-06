using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton_Script : MonoBehaviour {

    public SoundSettings soundSetting;
    public Button myButton;

	void Start () {
        soundSetting = FindObjectOfType<SoundSettings>();
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(soundSetting.MuteAll);
	}
	
	void Update () {
		
	}
}
