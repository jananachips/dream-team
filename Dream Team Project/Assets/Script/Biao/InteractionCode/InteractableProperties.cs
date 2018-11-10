using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//assign properties to object attached base on their tags, using the overall list we already had
public class InteractableProperties : MonoBehaviour {
    private string message = "This item doesn't have any description";

	void Start () {
        InterOverallInfo InteractionOverallInfo = FindObjectOfType<InterOverallInfo>();
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
