using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will belong to interactable objects

public class ObjectTrigger_Interaction : MonoBehaviour {
    //user can edit
    public float collider_XOffSet = 1;
    public float collider_yOffSet = 1;
    [Header("End Message On Exit Trigger")]
    public bool endMessageOnLeave = true;
    public string playerTag = "Player"; 

    //will read from default file
    public ScreenMessage_Manager screenMessage_Manager;
    private AssignProperties_Inter myScript;

    private GameObject parent;
    private string parentTag;
    private string parentName;

    private bool stillTalking = false;

    private Collider2D otherCollider;
    private void Start()
    {
        myScript = GetComponentInParent<AssignProperties_Inter>();
        parentName = this.transform.parent.name;
        parentTag = this.transform.parent.tag;

        screenMessage_Manager = FindObjectOfType<ScreenMessage_Manager>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider_temp)
    {
        otherCollider = otherCollider_temp;
        stillTalking = screenMessage_Manager.GetIsStillTalking();
        if (otherCollider.tag == playerTag && !stillTalking)
        {
            //always show basic info (for npc, the start conversation message)
            screenMessage_Manager.ScreenMessageConditionHandler(otherCollider, myScript);
        }

        //Debug.Log("the enter still talking value: " + stillTalking);


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        stillTalking = screenMessage_Manager.GetIsStillTalking();

        if (endMessageOnLeave || !stillTalking)
        {
            screenMessage_Manager.StopShowingMessage();
        }
    }


}
