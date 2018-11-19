using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Follow : MonoBehaviour {

    public float xOffset = -5;
    public float yOffset = 3;

    public Transform playerTransform;

	void Start () {
		
	}
	
	void LateUpdate () {
        transform.position = playerTransform.position + new Vector3(xOffset, yOffset, 0);
	}
}
