using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMessage_Action : MonoBehaviour {

    public GameObject popOutWindow;
    public Text popText;
    public Text continueRemainder;
    //public AudioSource typingSoundController;
    //public KeyListener_Inter KeyListener;
    public float messageLastTime = 3f;
    public float NPCMessageLastTime = 6f;


    //stop messages from overlapping each other
    private bool showingInfo = false;
    private GameObject tempWindow;

    private float TypingGap = 0.01f;
    private float Default_TypingGap = 0.01f;
    private bool stillTyping = false;

    private IEnumerator TypingEffectCoroutine;

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

    public void NpcConversation(string name, string message,  float messageLastTime = 3f)
    {
        ShowMessage("", message,  messageTime:messageLastTime ,isNpc:true, talking:true);
    }

    public void ShowMessage(string name, string message,  float messageTime = -100 ,bool isNpc = false, bool talking = false)
    {
        //main message
        string resultPopText;

        if(name.Length > 0)
        {
            resultPopText = "Name: " + name + "\n" + message;
        }else {
            resultPopText = message; 
        }

        if (GetIsStillTyping())
        {
            //stop previous, since isTyping return true, there must be one there
            StopCoroutine(TypingEffectCoroutine);
        }
        //the typing effect
        TypingEffectCoroutine = TypingEffect(resultPopText, messageTime, talking:talking, isNpc:isNpc);
        StartCoroutine(TypingEffectCoroutine);
    }

    //typing effect
    IEnumerator TypingEffect(string aString, float messageTime,  bool talking = false, bool isNpc = false)
    {
        stillTyping = true;
        string resultString = "";
        string resultRemainderText = "";
        float typingGap_Temp = TypingGap;

        foreach(char letter in aString)
        {
            //Debug.Log("typing gap now: " + typingGap_Temp);
            //main message
            if(typingGap_Temp > 0)
            {
                resultString = resultString + letter.ToString();
                //Debug.Log("result string is: " + resultString);
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
            if (isNpc)
            {
                messageTime = NPCMessageLastTime;
            }

            tempWindow = Instantiate(popOutWindow);
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
