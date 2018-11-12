using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put a (square collider) trigger in front of the player, when collide with things with tag "Interactable"
//word will pop out on the top, showing the name and the actions we can do with it

public class Trigger_Inter : MonoBehaviour {
    public float ListenGapTime = 0.01f;

    public ActionsToGame_Inter ActionsOnScreen;
    public KeyListener_Inter KeyListener;


    //FIXME will i use this???
    private string[] otherColliderProperties;


    private bool interactable = false;
    private bool isNpc = false;
    private string otherColliderTag;
    private string otherColliderName;
    private string otherColliderBasicMessage = "trigger failed to get message";
    private string[] otherColliderDialogueList;

	void Start () {
	}

    void ShowObjectBasicInfo()
    {
        ActionsOnScreen.ShowMessage(otherColliderName, otherColliderBasicMessage, transform, isNpc:isNpc);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        AssignProperties_Inter otherColliderScript = otherCollider.GetComponent<AssignProperties_Inter>();
        
        interactable = otherColliderScript.GetIsInteractable();
        isNpc = otherColliderScript.GetIsNpc();
        otherColliderBasicMessage = otherColliderScript.GetBasicMessage();
        otherColliderTag = otherCollider.tag;
        otherColliderName = otherCollider.name;


        if (interactable)
        {


            ShowObjectBasicInfo();
            if (isNpc)
            {
                otherColliderDialogueList = otherColliderScript.GetNpcDialogueList();

                KeyListener.ContinueListeningKeys = true;
                int conversationLength = otherColliderDialogueList.Length;
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
                isStillTyping = ActionsOnScreen.GetIsStillTyping();
                if (isStillTyping)
                {
                    //if previous sentence is still typing, speed up
                    ActionsOnScreen.ChangeTypingGapTo(0f);
                }
                else
                {
                    //else, type next sentence
                    ActionsOnScreen.ResetTypingGap();
                    ActionsOnScreen.NpcConversation("", otherColliderDialogueList[j], transform, messageLastTime:3f);
                    j++;
                }


            }
            else if(StopConversation)
            {
                Debug.Log("stop it");
                ActionsOnScreen.NpcConversation("", " :<",transform, messageLastTime:1.5f );
            }
            
            yield return new WaitForSeconds(gapTime);
        }


        KeyListener.ContinueListeningKeys = false;
    }
 

    private void OnTriggerExit2D(Collider2D collision)
    {
            if(interactable)
            {
                KeyListener.ContinueListeningKeys = false;
                ActionsOnScreen.ShowMessage("", "   :<\n  :<",transform, messageTime:1.5f );
            }

    }



}
