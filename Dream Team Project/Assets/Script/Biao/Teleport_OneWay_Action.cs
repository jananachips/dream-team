using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_OneWay_Action : MonoBehaviour {

    public Transform destinationTransform;

	void Start () {
        		
	}
	
	void Update () {
		
	}

    public void DoTeleport(Transform from, Transform to)
    {
        from.position = to.position;
        Debug.Log("action done!!!!!!!");
    }
}
