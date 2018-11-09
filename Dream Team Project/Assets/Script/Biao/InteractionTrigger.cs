using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put a (square collider) trigger in front of the player, when collide with things with tag "Interactable"
//a bubble will pop out, showing the name and the actions we can do with it
public class InteractionTrigger : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string message, name;
        if(collision.tag == "Interactable")
        {

            message = collision.GetComponent<InteractableProperties>().GetMessage();
            name = collision.GetComponent<InteractableProperties>().GetName();
            //Debug.Log("I will do this");
            //Debug.Log(name);
            //Debug.Log(message);
            FindObjectOfType<InteractionManager>().showMessage(name, message, collision.transform);
        }
    }
}
