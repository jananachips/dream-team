using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_AutoSize : MonoBehaviour {

    public BoxCollider2D myTrigger;

    public float scaleX;
    public float scaleY;
    public float scaleZ;

	void Start () {
        /*
        myTrigger = GetComponent<BoxCollider2D>();
        scaleX = transform.parent.localScale.x;
        scaleY = transform.parent.localScale.y;

        myTrigger.size = new Vector2(scaleX, scaleY);
        */
	}
	
	void Update () {
		
	}
}
