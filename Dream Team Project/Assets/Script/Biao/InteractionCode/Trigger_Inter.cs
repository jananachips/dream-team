using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put a (square collider) trigger in front of the player, when collide with things with tag "Interactable"
//word will pop out on the top, showing the name and the actions we can do with it

public class Trigger_Inter : MonoBehaviour {
    public Actions_Inter ActionsOnScreen;
    public float ListenGapTime = 0.01f;
    public KeyListener_Inter KeyListener;

    private bool interactable = false;
    private string[] InteractableTagsList;
    private DialoguesFormat[] nameAndDialogues;

	void Start () {
        //some initialization can not put on start, especially when it's from another code, I guess bc it could be this method being 
        //called when the other code it depend on hasn't finished its initialization
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
            nameAndDialogues = ActionsOnScreen.GetNameAndDialogues();

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
            InteractableTagsList = ActionsOnScreen.GetInteractableList();

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        //stop wait for input when player leave the area 
        KeyListener.ContinueListeningKeys = false;
    }

    IEnumerator  NpcConversation(int i, int conversationLength, float gapTime)
    {
        bool UserPressedKey = false;
        bool StopConversation = false;
        for(int j = 0;  j < conversationLength && KeyListener.ContinueListeningKeys;)
        {
            UserPressedKey = KeyListener.GetIsKeyPressed();
            StopConversation = KeyListener.StopTalkNow();
            if (UserPressedKey && !StopConversation)
            {
                //Debug.Log("continue: userpressed " + j);
                ActionsOnScreen.NpcConversation("", nameAndDialogues[i].dialogue[j], transform, messageLastTime:3f);
                j++;

            }
            else if(StopConversation)
            {
                Debug.Log("stop it");
                ActionsOnScreen.NpcConversation("", " :<",transform, messageLastTime:1.5f );
            }
            
            yield return new WaitForSeconds(gapTime);
        }

        //when conversation ends, the stop will stop responding..not that it's not working

        KeyListener.ContinueListeningKeys = false;
    }
 

}
