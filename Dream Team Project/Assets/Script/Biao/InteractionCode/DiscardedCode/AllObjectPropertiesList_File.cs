using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectPropertiesList_File : MonoBehaviour {
    [SerializeField]
    public Format_TagsAndProperties[] tagsAndProperties;
    //public Format_TagsAndProperties[] tagsAndDataProperties;


    public string[] GetActionPropertiesOfTag(string tagName)
    {
        string[] tagNameNotFoundMessage = new string[1] { "Tag name: " + tagName + " not found in the action properties list" };
        string[] emptyPropertyListMessage = new string[1] { "Tag name: " + tagName + " is not given action properties" };
        for(int i = 0; i < tagsAndProperties.Length; i++)
        {
            if (tagName == tagsAndProperties[i].ATagName)
            {
                if(tagsAndProperties[i].ItsAllActionProperties.Length == 0)
                {
                    return emptyPropertyListMessage;
                }
                return tagsAndProperties[i].ItsAllActionProperties;
            }
        }

        return tagNameNotFoundMessage;
    }

   
    public string[] GetDataPropertiesOfTag(string tagName)
    {
        string[] tagNameNotFoundMessage = new string[1] { "Tag name: " + tagName + " not found in the data properties list" };
        string[] emptyPropertyListMessage = new string[1] { "Tag name: " + tagName + " is not given data properties" };

        for(int i = 0; i < tagsAndProperties.Length; i++)
        {
            if (tagName == tagsAndProperties[i].ATagName)
            {
                if(tagsAndProperties[i].ItsAllDataProperties.Length == 0)
                {
                    return emptyPropertyListMessage;
                }
                return tagsAndProperties[i].ItsAllDataProperties;
            }
        }
        


        return tagNameNotFoundMessage;
    }

    
}
