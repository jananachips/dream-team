using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectPropertiesList_File : MonoBehaviour {
    [SerializeField]
    public Format_TagsAndProperties[] tagsAndProperties;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public string[] GetPropertiesOfTag(string tagName)
    {
        for(int i = 0; i < tagsAndProperties.Length; i++)
        {
            if (tagName == tagsAndProperties[i].ATagName)
            {
                return tagsAndProperties[i].ItsAllProperties;
            }
        }

        Debug.Log("tag name: " + tag + " not in the properties list");
        return null;
    }

    
}
