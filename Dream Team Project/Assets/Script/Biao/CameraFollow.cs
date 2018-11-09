using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform playerTransform;
    public float xOffSet = -1;
    public float yOffSet = 1;
    public float zOffSet = -10;

    public bool followPlayer = true;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (followPlayer)
        {
            transform.position = playerTransform.position + new Vector3(xOffSet, yOffSet, zOffSet);
        }
	}
}
