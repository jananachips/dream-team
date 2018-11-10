using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectInfoList_Inter : MonoBehaviour {
    [SerializeField]
    public string[] InteractableTagsList;
    [TextArea(3,10)]
    public string[] CorrespondingMessage;
		
    public string[] WhatCanBeInteracted()
    {
        return InteractableTagsList;
    }

    public string[] WhatIsTheMessage()
    {
        return CorrespondingMessage;
    }
}
