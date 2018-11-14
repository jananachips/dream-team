using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will be attached onto any interactable objects
//search for the basic information of current attached objective from AllObjectInfoList_File
//with basic information, 

//if object have special actions, new script will be added
public class AssignProperties_Inter: MonoBehaviour {

    private AllObjectInfoList_File allObjectInfoList_File;
    private AllObjectPropertiesList_File allObjectPropertiesList_File;
    private AllDialoguesList_File allDialoguesList_File;

    public string[] npcDialogueList;
    public bool isInteractable = false;
    public bool isNpc = false;
    public string myBasicMessage = "no basic message given";

        //DO NOT CHANGE THIS TO start()
	void Awake () {

        allObjectInfoList_File = FindObjectOfType<AllObjectInfoList_File>();
        allDialoguesList_File = FindObjectOfType<AllDialoguesList_File>();

        isInteractable = allObjectInfoList_File.GetIsInteractable(tag);
        myBasicMessage = allObjectInfoList_File.GetBasicMessageOf(tag);


        isNpc = allDialoguesList_File.GetIsNpc(name);
        if (isNpc)
        {
            npcDialogueList = allDialoguesList_File.GetDialogueListOf(name);
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
