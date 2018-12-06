using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will belong to interactable objects

public class ObjectTrigger_Interaction : MonoBehaviour {
    [Header("Use My Addjusted Value, not default")]
    public bool notChangeCollider = false;
    public bool UseMyAddjustedValue = false;
    public float collider_XSize = 1;
    public float collider_ySize = 1;
    public bool displayMessages = true;
    public bool onlyDisplayOnce = false;
    public int triggerCount = 0;

    [Space]
    [Header("End Message On Exit Trigger")]
    public bool endMessageOnLeave = true;
    public string playerTag = "Player"; 

    //will read from default file
    public ScreenMessage_Manager screenMessage_Manager;
    private AssignProperties_Inter myScript;
    private BoxCollider2D myBoxCollider2D;

    private GameObject parent;
    private string parentTag;
    private string parentName;

    private bool stillTalking = false;

    private Collider2D otherCollider;
    private void Start()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myScript = GetComponentInParent<AssignProperties_Inter>();
        parentName = this.transform.parent.name;
        parentTag = this.transform.parent.tag;

        if (!UseMyAddjustedValue)
        {
            collider_XSize = 2f;
            collider_ySize = 2f;
            displayMessages = true;
        }

        if (!notChangeCollider)
        {
            myBoxCollider2D.size = new Vector2(collider_XSize, collider_ySize);
        }

        screenMessage_Manager = FindObjectOfType<ScreenMessage_Manager>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider_temp)
    {
        if (displayMessages)
        {
            otherCollider = otherCollider_temp;
            stillTalking = screenMessage_Manager.GetIsStillTalking();
            if (otherCollider.tag == playerTag && !stillTalking)
            {
                //always show basic info (for npc, the start conversation message)
                screenMessage_Manager.ScreenMessageConditionHandler(otherCollider, myScript);

                //new
                triggerCount++;
                if (onlyDisplayOnce && triggerCount >= 1)
                {
                    //disable collider
                    //myBoxCollider2D.enabled = false;
                    displayMessages = false;
                }
            }

            //Debug.Log("the enter still talking value: " + stillTalking);
        }


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        stillTalking = screenMessage_Manager.GetIsStillTalking();

        if (endMessageOnLeave && !stillTalking)
        {
            //Debug.Log("end conversation");
            //Debug.Log("my name: " + name);
            //Debug.Log("other: " + collision.name);
            screenMessage_Manager.StopShowingMessage();
        }
    }


}
