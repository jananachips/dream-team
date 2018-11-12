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

    private float TypingGap = 0.03f;
    private float Default_TypingGap = 0.03f;
    private bool stillTyping = false;

    public bool GetIsStillTyping()
    {
        return stillTyping;
    }

    public void ChangeTypingGapTo(float time)
    {
        TypingGap = time;
    }
    
    public void ResetTypingGap()
    {
        TypingGap = Default_TypingGap;
    }

    public void NpcConversation(string name, string message, Transform desiredTransform, float messageLastTime = 3f)
    {
        ShowMessage("", message, desiredTransform, messageTime:messageLastTime ,isNpc:true, talking:true);
    }

    public void ShowMessage(string name, string message, Transform desiredTransform, float messageTime = -100 ,bool isNpc = false, bool talking = false)
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
        //StartCoroutine(TypingEffect(resultPopText, messageTime, desiredTransform, talking:talking, isNpc:isNpc));
        IEnumerator TypingEffectCoroutine = TypingEffect(resultPopText, messageTime, desiredTransform, talking:talking, isNpc:isNpc);
        StartCoroutine(TypingEffectCoroutine);
    }

    //typing effect
    IEnumerator TypingEffect(string aString, float messageTime, Transform wantedTransform,  bool talking = false, bool isNpc = false)
    {
        stillTyping = true;
        string resultString = "";
        string resultRemainderText = "";
        float typingGap_Temp = TypingGap;

        foreach(char letter in aString)
        {
            //main message
            if(typingGap_Temp > 0)
            {
                resultString = resultString + letter.ToString();
            }
            else
            {
                resultString = aString;
            }
            popText.text = resultString;

            //remainder part not effect..
            if (talking)
            {
                resultRemainderText = "Press E To Continue";
            }else if(!talking && isNpc)
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

            //
            tempWindow = Instantiate(popOutWindow, wantedTransform);
            showingInfo = true;

            Destroy(tempWindow, messageTime);

            //update typingGap, so we can speed up when player dont want to wait and press next

            if(typingGap_Temp == 0)
            {
                break;
            }
            typingGap_Temp = TypingGap;
            yield return new WaitForSeconds(typingGap_Temp);
        }

        //when done typing, reset to default
        ResetTypingGap();
        stillTyping = false;
    }




}
