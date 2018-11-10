using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterOverallInfo : MonoBehaviour {
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
