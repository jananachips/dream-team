using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;

public class OneWayTeleport_SpecT : MonoBehaviour {

    [Header("Additional Trigger behavior")]
    public string InfoForYou;

    public Teleport_OneWay_Manager teleportOneWay_Manager;

    private void Start()
    {
        InfoForYou = "Additional Trigger Behavior for OneWayTeleporter";
    }



    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player")
        {
            Transform destination = this.transform.parent.GetChild(1);
            Transform teleportTransform = this.transform.parent;
            teleportOneWay_Manager.ReadyToTeleport(otherCollider.transform, destination, teleportTransform);
        }
        
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit in specT");
        if(collision.tag == "Player")
        {
            teleportOneWay_Manager.TeleportExpire();
        }
    }
}
