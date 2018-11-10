using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handle that actions when player find the interactable object and want to do something with it
//do things like: open the box, etc

public class Actions_Inter: MonoBehaviour {
    public GameObject popOutWindow;
    public Text popText;

    public AllObjectInfoList_Inter interactObjects;
    public AllDialogues allDialogues;
    public float waitTime = 3f;

    //stop messages from overlapping each other
    private bool showingInfo = false;
    private GameObject tempWindow;
    private string[] InteractableList;
    private DialoguesFormat[] nameAndDialogues;
    private string testVar = "hi";
	void Start () {
        InteractableList = interactObjects.WhatCanBeInteracted();
        nameAndDialogues = allDialogues.GetNameAndDialogues();
        string[] temp = GetInteractableList();
	}
    private void Awake()
    {
    }

    public string[] GetInteractableList()
    {
        return InteractableList;
    }
	
	void Update () {
		
	}
    public void ShowMessage(string name, string message, Transform desiredTransform)
    {
        Debug.Log("in the show message");
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
    
    public void NpcConversation(string name, string message, Transform desiredTransform)
    {
        Debug.Log("conversation in manager");
        ShowMessage(name, message, desiredTransform);
    }


    public DialoguesFormat[] GetNameAndDialogues()
    {
        return nameAndDialogues;
    }


}
