using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will be attached onto any interactable objects
//search for the basic information of current attached objective from AllObjectInfoList_File
//with basic information, 

//if object have special actions, new script will be added
public class AssignProperties_Inter: MonoBehaviour {



    [Header("Use My Addjusted Value, not default")]
    public bool UseMyAddjustedValue = false;
    [Space]
    public bool isInteractable = false;
    public bool isNpc = false;
    public string myBasicMessage = "no basic message given";
    [TextArea(3,10)] public string[] npcDialogueList;

    //private AllObjectPropertiesList_File allObjectPropertiesList_File;
    private AllObjectInfoList_File allObjectInfoList_File;
    private AllDialoguesList_File allDialoguesList_File;

        //DO NOT CHANGE THIS TO start()
	void Awake () {

        allObjectInfoList_File = FindObjectOfType<AllObjectInfoList_File>();
        allDialoguesList_File = FindObjectOfType<AllDialoguesList_File>();

        //if user decides they want to use their value, then don't initialize
        if (!UseMyAddjustedValue)
        {
            isInteractable = allObjectInfoList_File.GetIsInteractable(tag);
            myBasicMessage = allObjectInfoList_File.GetBasicMessageOf(tag);
            isNpc = allDialoguesList_File.GetIsNpc(name);
        }


        if (isNpc)
        {
            if(npcDialogueList.Length == 0 && !UseMyAddjustedValue)
            {
                npcDialogueList = allDialoguesList_File.GetDialogueListOf(name);
            }

            if(npcDialogueList.Length == 0)
            {
                npcDialogueList = new string[1] { "empty dialogue" };
            }
        }
        else
        {
            npcDialogueList = new string[1]{"not npc, no dialogue"};
        }


	}
	

}
