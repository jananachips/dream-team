using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Move : MonoBehaviour {
    public string startPt_Name = "PatrolMove_StartPt";
    public string endPt_Name = "PatrolMove_EndPt";
    public bool movingPts = false;

    public Transform startPtTr;
    public Transform endPtTr;
    public Transform enemyTr;

    public Vector3 StartPt_Position;
    public Vector3 EndPt_Position;

    public bool reachStartPt = true;
    public bool reachEndPt = false;

    public Vector3 moveRateVec;
    private Vector3 diffVec;
    public float moveRate_Denominator = 3;

	void Start () {

        StartPt_Position = startPtTr.position;
        EndPt_Position = endPtTr.position;

        enemyTr.position = new Vector3(StartPt_Position.x, StartPt_Position.y, StartPt_Position.z);

        diffVec = EndPt_Position - StartPt_Position;
        moveRateVec = diffVec / moveRate_Denominator;

        startPtTr.GetComponent<SpriteRenderer>().enabled = false;
        endPtTr.GetComponent<SpriteRenderer>().enabled = false;

	}
	
	void Update () {

        if (movingPts)
        {
            StartPt_Position = startPtTr.position;
            EndPt_Position = endPtTr.position;

            //diffVec = EndPt_Position - StartPt_Position;

            if (!reachEndPt)
            {
                diffVec = EndPt_Position - transform.position;
            }else if (!reachStartPt)
            {
                //diffVec = StartPt_Position - transform.position;
                //make sure the negative sign in the translate works...
                diffVec = transform.position - StartPt_Position;
            }

            moveRateVec = diffVec / moveRate_Denominator;

        }

        //deltaTime is necessary!! otherwise it will stop even if the game is paused
	    if(reachStartPt && !reachEndPt)
        {
            enemyTr.Translate(moveRateVec * Time.deltaTime);
        }else if(!reachStartPt && reachEndPt)
        {
            enemyTr.Translate(-moveRateVec * Time.deltaTime);
        }
       


	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("the collision name: " + collision.name);
        if(collision.name == startPt_Name && reachStartPt == false)
        {
            reachStartPt = true;
            reachEndPt = false;
        }else if (collision.name == endPt_Name && reachEndPt == false)
        {
            reachStartPt = false;
            reachEndPt = true;
        }
    }
}
