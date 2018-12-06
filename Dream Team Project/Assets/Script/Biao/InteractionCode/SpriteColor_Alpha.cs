using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor_Alpha : MonoBehaviour {

    public Color myColor;
    public SpriteRenderer mySpriteRender;

	void Start () {
        myColor = mySpriteRender.color;
        mySpriteRender.color = new Color(myColor.r, myColor.g, myColor.b, 0);
	}
	
	void Update () {
		
	}
}
