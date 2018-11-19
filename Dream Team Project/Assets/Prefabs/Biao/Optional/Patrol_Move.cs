using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Move : MonoBehaviour {

    public Transform startPtTr;
    public Transform endPtTr;
    public Transform parentTr;

    public Vector3 StartPt_Position;
    public Vector3 EndPt_Position;

    public float moveAmount = 0.1f;
    public int startPt_Idx = 0;
    public int endPt_Idx = 1;
    public bool reachStartPt = true;
    public bool reachEndPt = false;

	void Start () {
        startPtTr = this.transform.GetChild(startPt_Idx);
        endPtTr = this.transform.GetChild(endPt_Idx);
        parentTr = this.transform.parent;

        StartPt_Position = startPtTr.position;
        EndPt_Position = endPtTr.position;

        startPtTr.gameObject.SetActive(false);
        endPtTr.gameObject.SetActive(false);
	}
	
	void Update () {
	    if(reachStartPt && transform.position.x < EndPt_Position.x)
        {
            //Debug.Log("move right");
            parentTr.Translate(moveAmount, 0, 0);
        }
        else
        {
            reachStartPt = false;
            reachEndPt = true;
        }

        if(reachEndPt && transform.position.x > StartPt_Position.x)
        {
            //Debug.Log("move left");
            parentTr.Translate(-moveAmount, 0, 0);
        }
        else
        {
            reachStartPt = true;
            reachEndPt = false;
        }
	}
}
