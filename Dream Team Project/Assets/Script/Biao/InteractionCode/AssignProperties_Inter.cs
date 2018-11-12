using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will be attached onto any interactable objects
//search for the basic information of current attached objective from AllObjectInfoList_File
//with basic information, assign it the properties from the properties list: AllObjectPropertiesList_File


public class AssignProperties_Inter: MonoBehaviour {

    private AllObjectInfoList_File allObjectInfoList_File;
    private AllObjectPropertiesList_File allObjectPropertiesList_File;
    private AllDialoguesList_File allDialoguesList_File;

    //private string message = "This item doesn't have any description";
    private string[] myProperties;
    private string[] npcDialogueList;
    private bool isInteractable = false;
    private bool isNpc = false;
    private string myBasicMessage = "no basic message given";

	void Start () {

        allObjectInfoList_File = FindObjectOfType<AllObjectInfoList_File>();
        allObjectPropertiesList_File = FindObjectOfType<AllObjectPropertiesList_File>();
        allDialoguesList_File = FindObjectOfType<AllDialoguesList_File>();

        isInteractable = allObjectInfoList_File.GetIsInteractable(tag);
        myBasicMessage = allObjectInfoList_File.GetBasicMessageOf(tag);
        myProperties = allObjectPropertiesList_File.GetPropertiesOfTag(tag);

        isNpc = allDialoguesList_File.GetIsNpc(name);
        if (isNpc)
        {
            npcDialogueList = allDialoguesList_File.GetDialogueListOf(name);
        }
        else
        {
            //could be wrong
            npcDialogueList = new string[1]{"not npc, no dialogue"};
        }


	}
	

    public string GetTag()
    {
        return tag;
    }

    public string GetName()
    {
        return name;
    }

    public string GetBasicMessage()
    {
        return myBasicMessage;
    }

    public string[] GetObjectProperties()
    {
        return myProperties;
    }

    public bool GetIsInteractable()
    {
        return isInteractable;
    }

    public string[] GetNpcDialogueListOf(string npcName)
    {
        return npcDialogueList;
    }
}
