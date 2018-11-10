using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//DO NOT CHANGE ANYTHING HERE
//OTHERWISE YOU MAY NEED TO RETYPE ALL THE DIALOGUES!!!
public class AllDialogues : MonoBehaviour {
    [SerializeField]
    public DialoguesFormat[] npcAndDialogues;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public DialoguesFormat[] GetNameAndDialogues()
    {
        return npcAndDialogues;
    }
}
