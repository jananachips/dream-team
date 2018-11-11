using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//assign properties to object attached base on their tags, using the InteractionOverallInfo list we already had
public class AssignProperties_Inter: MonoBehaviour {

    private AllObjectInfoList_File allObjInfoList_File;
    private string message = "This item doesn't have any description";

	void Start () {

        allObjInfoList_File = FindObjectOfType<AllObjectInfoList_File>();
        string[] interTagsList = allObjInfoList_File.WhatCanBeInteracted();
        string[] messageList = allObjInfoList_File.WhatIsTheMessage();

        //check what properties should current object has base on its tag
        for(int i = 0; i < interTagsList.Length; i++)
        {
            if(tag == interTagsList[i])
            {
                message = messageList[i];
                //more properties
                //
                //etc
            }
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

    public string GetMessage()
    {
        return message;
    }
}
