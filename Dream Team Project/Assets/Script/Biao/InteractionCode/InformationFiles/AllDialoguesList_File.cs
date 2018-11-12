using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//DO NOT CHANGE ANYTHING HERE
//OTHERWISE YOU MAY NEED TO RETYPE ALL THE DIALOGUES!!!
public class AllDialoguesList_File : MonoBehaviour {

    [SerializeField]
    public DialoguesFormat[] npcAndDialogues;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public DialoguesFormat[] GetNameAndDialogues()
    {
        return npcAndDialogues;
    }

    public string[] GetDialogueListOf(string npcName)
    {
        for(int i = 0; i < npcAndDialogues.Length; i++)
        {
            if(npcName == npcAndDialogues[i].NpcName)
            {
                return npcAndDialogues[i].NpcDialogueList;
            }
        }
        Debug.Log("Npc " + npcName + " is not found in the AllDialoguesList_File, so not dialogues");
        return null;
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
