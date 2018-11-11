using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handle that actions when player find the interactable object and want to do something with it
//do things like: open the box, etc

public class Actions_Inter: MonoBehaviour {
    public GameObject popOutWindow;
    public Text popText;
    public Text continueRemainder;

    public AllObjectInfoList_Inter interactObjects;
    public AllDialogues allDialogues;
    public KeyListener_Inter KeyListener;
    public float messageLastTime = 3f;

    //stop messages from overlapping each other
    private bool showingInfo = false;
    private GameObject tempWindow;
    private string[] InteractableList;
    private DialoguesFormat[] nameAndDialogues;
    private bool IsNpc = false;
    //private bool talking = false;
	void Start () {
        InteractableList = interactObjects.WhatCanBeInteracted();
        nameAndDialogues = allDialogues.GetNameAndDialogues();
        string[] temp = GetInteractableList();
	}

    public string[] GetInteractableList()
    {
        return InteractableList;
    }
	
	void Update () {
		
	}
    public void ShowMessage(string name, string message, Transform desiredTransform, float messageTime = -100 ,bool IsNpc_temp = false, bool talking = false)
    {
        //main message
        //popText.text = ("Name: " + name + "\n" + message);
        if(name.Length > 0)
        {
            popText.text = "Name: " + name + "\n" + message;
        }else {
            popText.text = message;
        }

        //the "continue" message
        if (talking)
        {
            continueRemainder.text = "Press E To Continue";
        }else if(!talking && IsNpc_temp)
        {
            continueRemainder.text = "Press E To Start Conversation";
        }
        else
        {
            continueRemainder.text = "";
        }

        if (showingInfo)
        {
            Destroy (tempWindow);
            showingInfo = false;
        }

        if(messageTime <= 0)
        {
            messageTime = messageLastTime;
        }

        tempWindow = Instantiate(popOutWindow, desiredTransform);
        showingInfo = true;

        Destroy(tempWindow, messageTime);


    }

    public void ShowNpcInfo(string name,  Transform desiredTransform, string message = "")
    {
        ShowMessage(name, message, desiredTransform, messageTime:3,IsNpc_temp:true);
    }

    public void NpcConversation(string name, string message, Transform desiredTransform, float messageLastTime = 3f)
    {
        ShowMessage("", message, desiredTransform, messageTime:messageLastTime ,IsNpc_temp:true, talking:true);
    }


    public DialoguesFormat[] GetNameAndDialogues()
    {
        return nameAndDialogues;
    }


}
