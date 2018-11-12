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

    public string[] myProperties;
    public string[] npcDialogueList;
    public bool isInteractable = false;
    public bool isNpc = false;
    public string myBasicMessage = "no basic message given";

	void Start () {


        allObjectInfoList_File = FindObjectOfType<AllObjectInfoList_File>();
        allObjectPropertiesList_File = FindObjectOfType<AllObjectPropertiesList_File>();
        allDialoguesList_File = FindObjectOfType<AllDialoguesList_File>();

        isInteractable = allObjectInfoList_File.GetIsInteractable(tag);
        myBasicMessage = allObjectInfoList_File.GetBasicMessageOf(tag);

        if (isInteractable)
        {
            myProperties = allObjectPropertiesList_File.GetPropertiesOfTag(tag);
            if(myProperties.Length == 0)
            {
                myProperties = new string[1] { "Empty properties" };
            }
        }
        else
        {
            myProperties = new string[1] { "not interactable, not properties given" };
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

    public string[] GetOtherObjectProperties()
    {
        return myProperties;
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
