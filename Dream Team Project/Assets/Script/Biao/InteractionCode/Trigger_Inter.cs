using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put a (square collider) trigger in front of the player, when collide with things with tag "Interactable"
//word will pop out on the top, showing the name and the actions we can do with it

public class Trigger_Inter : MonoBehaviour {
    public float ListenGapTime = 0.01f;

    public ActionsToGame_Inter ActionsOnScreen;
    public KeyListener_Inter KeyListener;
    public AllObjectInfoList_File allObjectInfo_list;
    public AllDialoguesList_File allDialogues_file;



    private bool interactable = false;
    private string[] InteractableTagsList;
    private DialoguesFormat[] nameAndDialogues;

	void Start () {
        //some initialization can not put on start, especially when it's from another code, I guess bc it could be this method being 
        //called when the other code it depend on hasn't finished its initialization
        InteractableTagsList = allObjectInfo_list.WhatCanBeInteracted();
        nameAndDialogues = allDialogues_file.GetNameAndDialogues();
	}

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        string message, name;
        if(collision.tag == "NPC")
        {
            //get the list
            //nameAndDialogues = ActionsOnScreen.GetNameAndDialogues();

            string otherName = collision.name;
            for(int i = 0; i < nameAndDialogues.Length; i++)
            {
                if(nameAndDialogues[i].NpcName == otherName)
                {
                    ActionsOnScreen.ShowNpcInfo(nameAndDialogues[i].NpcName, transform);
                    KeyListener.ContinueListeningKeys = true;

                    int conversationLength = nameAndDialogues[i].dialogue.Length;
                    //Debug.Log("before the cor");
                    StartCoroutine(NpcConversation(i, conversationLength, ListenGapTime));
                }
            }

        }
        else
        {
            //get the list

            for (int i = 0; i < InteractableTagsList.Length; i++)
            {
                if(InteractableTagsList[i] == collision.tag)
                {
                    interactable = true;
                }
            }

            if(interactable)
            { 
                message = collision.GetComponent<AssignProperties_Inter>().GetMessage();
                name = collision.GetComponent<AssignProperties_Inter>().GetName();
                ActionsOnScreen.ShowMessage(name, message, transform);
                interactable = false;
            }

            }        

    }


    IEnumerator  NpcConversation(int i, int conversationLength, float gapTime)
    {
        bool UserPressedKey = false;
        bool StopConversation = false;


        for(int j = 0;  j < conversationLength && KeyListener.ContinueListeningKeys;)
        {
            UserPressedKey = KeyListener.GetIsKeyPressed();
            //keep checking if the user pressed end key (n for this case)
            StopConversation = KeyListener.StopActionNow();
            

            //for loop will not end if no j++ or Stopconversation is not true
            if (UserPressedKey && !StopConversation)
            {
                ActionsOnScreen.NpcConversation("", nameAndDialogues[i].dialogue[j], transform, messageLastTime:3f);
                j++;

            }
            else if(StopConversation)
            {
                Debug.Log("stop it");
                ActionsOnScreen.NpcConversation("", " :<",transform, messageLastTime:1.5f );
            }
            
            //finish one loop and rest for gapTime seconds
            yield return new WaitForSeconds(gapTime);
        }


        KeyListener.ContinueListeningKeys = false;
    }
 

    private void OnTriggerExit2D(Collider2D collision)
    {
        //stop wait for input when player leave the area 

        for (int i = 0; i < InteractableTagsList.Length; i++)
        {
            if(collision.tag == InteractableTagsList[i])
            {
                KeyListener.ContinueListeningKeys = false;
                ActionsOnScreen.ShowMessage("", "   :<\n  :<",transform, messageTime:1.5f );
            }
        }

    }



}
