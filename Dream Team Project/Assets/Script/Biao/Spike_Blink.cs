using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Blink : MonoBehaviour {

    private BoxCollider2D myCollider;
    public Color origColor;

    public float oriAlpha = 1.0f;
    public float disabledAlpha = 0.05f;

    public float existTime = 1f;
    public float disabledTime = 2f;

    private string curState = "decrease";
    private float alphaChaningVal = 0.1f;
    private float alphaVal;

	void Start () {
        myCollider = GetComponent<BoxCollider2D>();
        origColor = GetComponent<SpriteRenderer>().color;

        StartCoroutine(SizeChanging());
	}
	
	void Update () {
		
	}


    IEnumerator SizeChanging()
    {
        float waitTime = 5f;

        while (true)
        {
           if(curState == "decrease")
            {
                waitTime = disabledTime;
                //alphaVal = alphaVal - alphaChaningVal;

                alphaVal = disabledAlpha;
                if(alphaVal <= disabledAlpha)
                {
                    alphaVal = disabledAlpha;
                    curState = "increase";
                }
                GetComponent<SpriteRenderer>().color = new Color(origColor.r, origColor.g, origColor.b, alphaVal);
            }
            else
            {
                waitTime = existTime;
                //alphaVal = alphaVal + alphaChaningVal;

                alphaVal = oriAlpha;
                if(alphaVal <= oriAlpha)
                {
                    alphaVal = oriAlpha;
                    curState = "decrease";
                }
                GetComponent<SpriteRenderer>().color = new Color(origColor.r, origColor.g, origColor.b, alphaVal);
            }

            if (myCollider.enabled)
            {
                myCollider.enabled = false;
            }
            else
            {
                myCollider.enabled = true;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }



}
