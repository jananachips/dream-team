using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_OneWay_Action : MonoBehaviour {

    //public Transform destinationTransform;

	void Start () {
        		
	}
	
	void Update () {
		
	}
    /*
    public void FollowAndExplode( Transform teleporterTransfrom, Transform to, bool explodeAfterUse, bool followPlayerTeleport)
    {
        //FIXME: not sure how to do the explode part yet
        if (followPlayerTeleport)
        {
            teleporterTransfrom.position = to.position;
        }
    }
    */

    public void DoTeleport(Transform from, Transform to)
    {
        from.position = to.position;
        Debug.Log("action done!!!!!!!");
    }
}
