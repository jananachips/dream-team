using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put a (square collider) trigger in front of the player, when collide with things with tag "Interactable"
//word will pop out on the top, showing the name and the actions we can do with it

public class InteractionTrigger : MonoBehaviour {
    public InteractionManager InteractManager;
    public InterOverallInfo InterOverallInfo;

    private string[] InteractableList;
    private bool interactable = false;
	void Start () {
        InteractableList = InterOverallInfo.WhatCanBeInteracted();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string message, name;
        for (int i = 0; i < InteractableList.Length; i++)
        {
            if(InteractableList[i] == collision.tag)
            {
                interactable = true;
            }
        }
        if(interactable)
        { 
            message = collision.GetComponent<InteractableProperties>().GetMessage();
            name = collision.GetComponent<InteractableProperties>().GetName();
            //FindObjectOfType<InteractionManager>().showMessage(name, message, collision.gameObject.transform);
            InteractManager.showMessage(name, message, transform);
            interactable = false;
        }
    }

}
