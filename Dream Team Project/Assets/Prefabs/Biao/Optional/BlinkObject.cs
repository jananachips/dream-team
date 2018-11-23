using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObject : MonoBehaviour {
    public float alphaMax = 1.0f;
    public float alphaMin = 0.05f;
    public float alphaChangeVal = 0.2f;

    private float blinkRate_S = 0.1f;
    private Color origColor;
    private float alphaVal;
    private string curState = "decrease";

	void Start () {
        origColor = GetComponent<SpriteRenderer>().color;	

	}

    public void DoBlinkObject()
    {
        StartCoroutine(BlinkGameObject());
    }

    IEnumerator BlinkGameObject()
    {
        while (true)
        {
           if(curState == "decrease")
            {
                alphaVal = alphaVal - alphaChangeVal;
                if(alphaVal <= alphaMin)
                {
                    alphaVal = alphaMin;
                    curState = "increase";
                }

                GetComponent<SpriteRenderer>().color = new Color(origColor.r, origColor.g, origColor.b, alphaVal);
            }
            else
            {
                alphaVal = alphaVal + alphaChangeVal;
                if(alphaVal >= alphaMax)
                {
                    alphaVal = alphaMax;
                    curState = "decrease";
                }

                GetComponent<SpriteRenderer>().color = new Color(origColor.r, origColor.g, origColor.b, alphaVal);
            }

            Debug.Log("alpha: " + alphaVal);
            yield return new WaitForSeconds(blinkRate_S);
        }


    }
}
