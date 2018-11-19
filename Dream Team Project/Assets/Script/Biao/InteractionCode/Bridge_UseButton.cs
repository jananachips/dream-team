using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_UseButton : MonoBehaviour {

    public ButtonCollider_Trigger buttonTrigger;

    public bool bridgeDown = false;

    public float funcCalls = 50f;
    public float gapTime = 0.001f;

    public float upDegree = 85f;
    public float downDegree = -85f;

    private float upRate;
    private float downRate;
	void Start () {
        upRate = upDegree / funcCalls;
        downRate = downDegree / funcCalls;
        //transform.parent.Rotate(0, 0, upDegree);
        StartCoroutine(ChangeToDegreeSlowly(upRate));
	}
	
	void Update () {
	    if(!bridgeDown && buttonTrigger.isButtonPressed)
        {
            bridgeDown = true;
            //transform.parent.Rotate(0, 0, downDegree);
            StartCoroutine(ChangeToDegreeSlowly(downRate));

        }else if (bridgeDown && !buttonTrigger.isButtonPressed)
        {
            bridgeDown = false;
            //transform.parent.Rotate(0, 0, 85);
            StartCoroutine(ChangeToDegreeSlowly(upRate));
        }
	}

    IEnumerator ChangeToDegreeSlowly(float angleRate)
    {
        for(int i = 0; i < funcCalls; i++)
        {
            transform.parent.Rotate(0, 0, angleRate);
            yield return new WaitForSeconds(gapTime);
        }
    }
}
