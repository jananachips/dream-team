using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//assign properties to object attached base on their tags, using the InteractionOverallInfo list we already had
public class AssignProperties_Inter: MonoBehaviour {
    private string message = "This item doesn't have any description";

	void Start () {
        AllObjectInfoList_Inter InteractionOverallInfo = FindObjectOfType<AllObjectInfoList_Inter>();
        string[] interTagsList = InteractionOverallInfo.WhatCanBeInteracted();
        string[] messageList = InteractionOverallInfo.WhatIsTheMessage();
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
	

    public string GetName()
    {
        return name;
    }

    public string GetMessage()
    {
        return message;
    }
}
