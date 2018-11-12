using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//trying to replace the trigger put on the player
//this will belong to interactable objects

public class ObjectTrigger_Interaction : MonoBehaviour {

    public float collider_XOffSet = 1;
    public float collider_yOffSet = 1;
    public ScreenMessage_Manager screenMessage_Manager;

    //FIXME will i use this???
    private string[] myProperties;


    private AssignProperties_Inter myScript;

    private void Start()
    {
        myScript = GetComponentInParent<AssignProperties_Inter>();

        screenMessage_Manager = FindObjectOfType<ScreenMessage_Manager>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        screenMessage_Manager.ScreenMessageConditionHandler(otherCollider, myScript);
    }


}
