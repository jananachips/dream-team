using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectPropertiesList_File : MonoBehaviour {
    [SerializeField]
    public Format_TagsAndProperties[] tagsAndProperties;


    public string[] GetPropertiesOfTag(string tagName)
    {
        string[] tagNameNotFoundMessage = new string[1] { "Tag name: " + tagName + " not found in the properties list" };
        string[] emptyPropertyListMessage = new string[1] { "Tag name: " + tagName + " is not given properties" };
        for(int i = 0; i < tagsAndProperties.Length; i++)
        {
            if (tagName == tagsAndProperties[i].ATagName)
            {
                if(tagsAndProperties[i].ItsAllProperties.Length == 0)
                {
                    return emptyPropertyListMessage;
                }
                return tagsAndProperties[i].ItsAllProperties;
            }
        }

        return tagNameNotFoundMessage;
    }

    
}
