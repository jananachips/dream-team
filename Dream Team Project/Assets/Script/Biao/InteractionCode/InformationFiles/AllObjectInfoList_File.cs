using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectInfoList_File : MonoBehaviour {
    [SerializeField]
    public string[] interactableTagsList;
    [TextArea(3,10)]
    public string[] correspondingMessage;
		
    public string[] GetWhatCanBeInteractedList()
    {
        return interactableTagsList;
    }

    public string[] GetBasicMessageList()
    {
        return correspondingMessage;
    }

    public string GetBasicMessageOf(string tagName)
    {
        for(int i = 0; i < interactableTagsList.Length; i++)
        {
            if(tagName == interactableTagsList[i])
            {
                return correspondingMessage[i];
            }
        }

        Debug.Log("Tag " + tagName + " not found, so no corresponding basic message");
        return null;
    }

    public bool GetIsInteractable(string tagName)
    {
        for(int i = 0; i < interactableTagsList.Length; i++)
        {
            if(tagName == interactableTagsList[i])
            {
                return true;
            }
        }
        
        return false;

    }
}
