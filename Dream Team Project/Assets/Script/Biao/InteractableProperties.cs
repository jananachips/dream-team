using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attached to anything that player can interact with
//contain things like object's properties
//for ex: name, weight, damage, etc.

public class InteractableProperties : MonoBehaviour {
    private string objectName = "The first box";
    private string message = "Press E to open";
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetName()
    {
        return objectName;
    }

    public string GetMessage()
    {
        return message;
    }
}
