using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put a (square collider) trigger in front of the player, when collide with things with tag "Interactable"
//word will pop out on the top, showing the name and the actions we can do with it

public class Trigger_Inter : MonoBehaviour {
    public Actions_Inter InteractManager;
    public float talkGapTime = 2.5f;

    private bool interactable = false;
    private string[] InteractableTagsList;
    private DialoguesFormat[] nameAndDialogues;
	void Start () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractManager.GetInteractableList();
        InteractableTagsList = InteractManager.GetInteractableList();
        nameAndDialogues = InteractManager.GetNameAndDialogues();
        string message, name;
        if(collision.tag == "NPC")
        {
            string otherName = collision.name;
            for(int i = 0; i < nameAndDialogues.Length; i++)
            {
                if(nameAndDialogues[i].NpcName == otherName)
                {
                    //for(int j = 0; j < nameAndDialogues[i].dialogue.Length; j++)
                    int conversationLength = nameAndDialogues[i].dialogue.Length;
                    StartCoroutine(NpcConversation(i, conversationLength, talkGapTime));
                    //InteractManager.NpcConversation(nameAndDialogues[i].NpcName, nameAndDialogues[i].dialogue[j], transform);
                    Debug.Log("inside npc");
                }
            }

        }
        else
        {
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
                InteractManager.ShowMessage(name, message, transform);
                interactable = false;
            }

            }        

    }

    IEnumerator  NpcConversation(int i, int conversationLength, float gapTime)
    {
        for(int j = 0; j < conversationLength; j++)
        {
            Debug.Log("cor");
            InteractManager.NpcConversation(nameAndDialogues[i].NpcName, nameAndDialogues[i].dialogue[j], transform);
            yield return new WaitForSeconds(gapTime);
        }
    }

}
