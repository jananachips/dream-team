using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handle that actions that will affect the game when player find the interactable object and want to do something with it
//do things like: open the box, etc

public class ActionsToGame_Inter: MonoBehaviour {
    public GameObject popOutWindow;
    public Text popText;
    public Text continueRemainder;
    //public AudioSource typingSoundController;
    public KeyListener_Inter KeyListener;
    public float messageLastTime = 3f;


    //stop messages from overlapping each other
    private bool showingInfo = false;
    private GameObject tempWindow;


	void Start () {
	}

	
	void Update () {
		
	}

    public void ShowNpcInfo(string name,  Transform desiredTransform, string message = "")
    {
        ShowMessage(name, message, desiredTransform, messageTime:3,IsNpc:true);
    }

    public void NpcConversation(string name, string message, Transform desiredTransform, float messageLastTime = 3f)
    {
        ShowMessage("", message, desiredTransform, messageTime:messageLastTime ,IsNpc:true, talking:true);
    }

    public void ShowMessage(string name, string message, Transform desiredTransform, float messageTime = -100 ,bool IsNpc = false, bool talking = false)
    {
        //main message
        string resultPopText;

        if(name.Length > 0)
        {
            resultPopText = "Name: " + name + "\n" + message;
        }else {
            resultPopText = message; 
        }

        //the typing effect
        StartCoroutine(TypingEffect(resultPopText, messageTime, desiredTransform, talking:talking, IsNpc:IsNpc));
    }

    //typing effect
    IEnumerator TypingEffect(string aString, float messageTime, Transform wantedTransform,  bool talking = false, bool IsNpc = false)
    {
        string resultString = "";
        string resultRemainderText = "";
        foreach(char letter in aString)
        {
            //main message
            resultString = resultString + letter.ToString();
            popText.text = resultString;

            //remainder part not effect..
            if (talking)
            {
                resultRemainderText = "Press E To Continue";
            }else if(!talking && IsNpc)
            {
                resultRemainderText = "Press E To Start Conversation";
            }
            else
            {
                continueRemainder.text = "";
            }

            continueRemainder.text = resultRemainderText;


            //destroy previous message if there is any
            //if no, destroy after messageLastTime seconds
            if (showingInfo)
            {
                Destroy (tempWindow);
                showingInfo = false;
            }

            if(messageTime <= 0)
            {
                messageTime = messageLastTime;
            }

            tempWindow = Instantiate(popOutWindow, wantedTransform);
            showingInfo = true;

            Destroy(tempWindow, messageTime);
            yield return new WaitForSeconds(0.03f);
        }


    }




}
