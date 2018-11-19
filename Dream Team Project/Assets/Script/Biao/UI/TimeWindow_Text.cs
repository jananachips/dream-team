using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeWindow_Text : MonoBehaviour {

    private Text timeWindow_Text;
    private TimeCounter_Manager timeCounter_Manager;

    private void Awake()
    {
        timeWindow_Text = GetComponent<Text>();
        timeCounter_Manager = FindObjectOfType<TimeCounter_Manager>();
        timeWindow_Text.text = timeCounter_Manager.GetTimeCountString();
    }
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timeWindow_Text.text = timeCounter_Manager.GetTimeCountString();
	}

}
