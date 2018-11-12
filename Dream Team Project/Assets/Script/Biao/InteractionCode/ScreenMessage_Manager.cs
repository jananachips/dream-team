﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenMessage_Manager : MonoBehaviour {

    public float ListenGapTime = 0.01f;
    public KeyListener_Inter KeyListener;

    public ScreenMessage_Action screenMessage_Action;

    private string otherColliderTag;
    private string otherColliderName;
    private string objectName;
    private AssignProperties_Inter objectScript;
	void Start () {
		
	}
	
	void Update () {
		
	}

    public void ScreenMessageConditionHandler(Collider2D otherCollider, AssignProperties_Inter objectScript_temp)
    {


        otherColliderTag = otherCollider.tag;
        otherColliderName = otherCollider.name;

        objectScript = objectScript_temp;
        objectName = objectScript.name;

        if(otherColliderTag == "Player" && objectScript.isInteractable)
        {
            screenMessage_Action.ShowMessage(objectName, objectScript.myBasicMessage,  isNpc:objectScript.isNpc);

            if (objectScript.isNpc)
            {

                KeyListener.ContinueListeningKeys = true;
                int conversationLength = objectScript.npcDialogueList.Length;
                StartCoroutine(NpcConversation(conversationLength, ListenGapTime));
            }
        }
    }


    IEnumerator  NpcConversation(int conversationLength, float gapTime)
    {
        bool UserPressedKey = false;
        bool StopConversation = false;
        bool isStillTyping = false;

        for(int j = 0;  j < conversationLength && KeyListener.ContinueListeningKeys;)
        {
            UserPressedKey = KeyListener.GetIsKeyPressed();
            //keep checking if the user pressed end key (n for this case)
            StopConversation = KeyListener.StopActionNow();
            

            //for loop will not end if no j++ or Stopconversation is not true
            if (UserPressedKey && !StopConversation )
            {
                isStillTyping = screenMessage_Action.GetIsStillTyping();
                if (isStillTyping)
                {
                    //if previous sentence is still typing, speed up
                    screenMessage_Action.ChangeTypingGapTo(0f);
                }
                else
                {
                    //else, type next sentence
                    screenMessage_Action.ResetTypingGap();
                    screenMessage_Action.NpcConversation("", objectScript.npcDialogueList[j], messageLastTime:3f);
                    j++;
                }


            }
            else if(StopConversation)
            {
                Debug.Log("stop it");
                screenMessage_Action.NpcConversation("", " :<", messageLastTime:1.5f );
            }
            
            yield return new WaitForSeconds(gapTime);
        }


        KeyListener.ContinueListeningKeys = false;
    }








}