using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will belong to interactable objects

public class ObjectTrigger_Interaction : MonoBehaviour {

    public float collider_XOffSet = 1;
    public float collider_yOffSet = 1;
    public Teleport_OneWay_Manager teleportOneWay_Manager;


    //FIXME will i use this???
    private string[] myActionProperties;
    private string[] myDataProperties;


    private ScreenMessage_Manager screenMessage_Manager;
    private AssignProperties_Inter myScript;

    private GameObject parent;
    private string parentTag;
    private string parentName;

    private Collider2D otherCollider;
    private void Start()
    {
        myScript = GetComponentInParent<AssignProperties_Inter>();
        parentName = this.transform.parent.name;
        parentTag = this.transform.parent.tag;

        screenMessage_Manager = FindObjectOfType<ScreenMessage_Manager>();
        myActionProperties = myScript.myActionProperties;
        myDataProperties = myScript.myDataProperties;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider_temp)
    {
        otherCollider = otherCollider_temp;
        //always show basic info (for npc, the start conversation message)
        screenMessage_Manager.ScreenMessageConditionHandler(otherCollider, myScript);

        //FIXME: may cause trouble if the action is always running, for loop stuck
        if(otherCollider.tag == "Player")
        {
            for(int i = 0; i < myActionProperties.Length; i++)
            {
                ActionProperties_CaseHandler(myActionProperties[i]);
            }

        }

    }

    //for now, one object one action property... not sure how to do multiple action properties at the same time yet

    //I hard code this part, need to change if there is name change or so
    private void ActionProperties_CaseHandler(string actionName)
    {
        switch (actionName)
        {
            case "Teleport":
                Debug.Log("I'm doing the Teleport for you right now");
                //should be 1 since trigger maybe 0
                Transform destination = this.transform.parent.GetChild(1);
                //this.transform.parent.transform = destination;
                //otherCollider.transform.position = destination.position;
                //teleportOneWay_Manager = FindObjectOfType<Teleport_OneWay_Manager>();
                teleportOneWay_Manager.ReadyToTeleport(otherCollider.transform, destination);
                break;

            default:
                Debug.Log("action " + actionName + " not found");
                break;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        screenMessage_Manager.StopShowingMessage();
        if(parentTag == "Teleporter" && collision.tag == "Player")
        {
            teleportOneWay_Manager.TeleportExpire();
        }
    }

}
