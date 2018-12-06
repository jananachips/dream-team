using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlinking_Manager: MonoBehaviour {
    //private Text textToBlink;
    private float blinkRate_S = 0.1f;
    public float alphaMaxVal = 1.0f;
    public float alphaMinVal = 0.05f;
    private float alphaChangeVal = 0.05f;

    //private bool keepRunning = true;
    private Text myText;
    private Color originalColor;
    private float alphaVal;
    private string alphaState;
    private IEnumerator corTemp;

	void Start () {
        originalColor = GetComponent<Text>().color;
        //alphaVal = 0.2f;
        alphaState = "decrease";
        myText = GetComponent<Text>();

	}

    public void DoTextBlinking()
    {
        corTemp = BlinkText();
        StartCoroutine(corTemp);
    }

    public void StopTextBlinking()
    {
        StopCoroutine(corTemp);
    }
	
	void Update () {
	}


    IEnumerator BlinkText()
    {
        for(int i = 0; i < 100; )
        {


            if(alphaState == "decrease")
            {
                alphaVal = alphaVal - alphaChangeVal;
                if(alphaVal <= alphaMinVal)
                {
                    alphaState = "increase";
                    //yield return new WaitForSecondsRealtime(1f);
                }

                GetComponent<Text>().color = new Color(originalColor.r, originalColor.g, originalColor.b, alphaVal);

            }else
            {
                alphaVal = alphaVal + alphaChangeVal;
                if(alphaVal >= alphaMaxVal)
                {
                    alphaState = "decrease";
                }
                GetComponent<Text>().color = new Color(originalColor.r, originalColor.g, originalColor.b, alphaVal);
            }



            yield return new WaitForSecondsRealtime(blinkRate_S);



        }


    }



}
