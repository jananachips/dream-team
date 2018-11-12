using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//DO NOT CHANGE ANYTHING HERE
//OTHERWISE YOU MAY NEED TO RETYPE ALL THE DIALOGUES!!!
public class AllDialoguesList_File : MonoBehaviour {

    [SerializeField]
    public DialoguesFormat[] npcAndDialogues;


    public DialoguesFormat[] GetNameAndDialogues()
    {
        return npcAndDialogues;
    }

    public string[] GetDialogueListOf(string npcName)
    {
        string[] notFoundMessage = new string[1] {"Npc " + npcName + " not found, so no dialogue"};
        for(int i = 0; i < npcAndDialogues.Length; i++)
        {
            if(npcName == npcAndDialogues[i].NpcName)
            {
                return npcAndDialogues[i].NpcDialogueList;
            }
        }
        //Debug.Log("Npc " + npcName + " is not found in the AllDialoguesList_File, so not dialogues");
        return notFoundMessage;
    }

    public bool GetIsNpc(string npcName)
    {
        for(int i = 0; i < npcAndDialogues.Length; i++)
        {
            if(npcName == npcAndDialogues[i].NpcName)
            {
                return true;           }
        }
        return false;

    }
}
