using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handle that actions when player find the interactable object and want to do something with it
//do things like: open the box, etc

public class InteractionManager : MonoBehaviour {
    public GameObject popOutWindow;
    public Text popText;

    public float xOffSet = 0;
    public float yOffSet = 1;
    public float zOffset = 0;
    public float waitTime = 3f;

    //stop messages from overlapping each other
    private bool showingInfo = false;
    private GameObject tempWindow;
	void Start () {
		
	}
	
	void Update () {
		
	}

    public void showMessage(string name, string message, Transform desiredTransform)
    {

        popText.text = ("Name: " + name + "\n" + message);
        if (showingInfo)
        {
            Destroy (tempWindow);
        }
        tempWindow = Instantiate(popOutWindow, desiredTransform);
        showingInfo = true;

        Destroy(tempWindow, waitTime);

        Debug.Log("I got it" + name + " " + message);

    }






}
