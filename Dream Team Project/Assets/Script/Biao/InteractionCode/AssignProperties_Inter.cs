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

    public string[] myActionProperties;
    public string[] myDataProperties;
    public string[] npcDialogueList;
    public bool isInteractable = false;
    public bool isNpc = false;
    public string myBasicMessage = "no basic message given";

	void Awake () {


        allObjectInfoList_File = FindObjectOfType<AllObjectInfoList_File>();
        allObjectPropertiesList_File = FindObjectOfType<AllObjectPropertiesList_File>();
        allDialoguesList_File = FindObjectOfType<AllDialoguesList_File>();

        isInteractable = allObjectInfoList_File.GetIsInteractable(tag);
        myBasicMessage = allObjectInfoList_File.GetBasicMessageOf(tag);

        if (isInteractable)
        {
            myActionProperties = allObjectPropertiesList_File.GetActionPropertiesOfTag(tag);
            myDataProperties = allObjectPropertiesList_File.GetDataPropertiesOfTag(tag);


         }

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
	


    //may remove this later, after I finish object trigger
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

    public string[] GetObjectActionProperties()
    {
        return myActionProperties;
    }

    public string[] GetObjectDataProperties()
    {
        return myDataProperties;
    }

    public bool GetIsInteractable()
    {
        return isInteractable;
    }

    public string[] GetNpcDialogueList()
    {
        return npcDialogueList;
    }

    public bool GetIsNpc()
    {
        return isNpc;
    }
}
