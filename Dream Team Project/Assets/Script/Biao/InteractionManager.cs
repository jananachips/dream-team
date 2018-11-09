using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handle that actions when player find the interactable object and want to do something with it
//do things like: open the box, etc

public class InteractionManager : MonoBehaviour {
    public GameObject popOutWindow;
    public Text popText;

    public float xOffSet = 0;
    public float yOffSet = 1;
    public float zOffset = 0;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void showMessage(string name, string message, Transform OtherTransform)
    {
        //popOutWindow.transform.position = OtherTransform.position + new Vector3(xOffSet, yOffSet, zOffset);
        //popOutWindow.transform.SetParent(OtherTransform+ new Vector3(xOffSet, yOffSet, zOffset));
        //not sure how to apply the offset yet
        
        popOutWindow.transform.SetParent(OtherTransform);
        popText.text = ("Name: " + name + "\n" + message);
        popOutWindow.SetActive(true);

        Debug.Log("I got it" + name + " " + message);
        StartCoroutine(disablePopWindow());
    }

        
    IEnumerator disablePopWindow()
    {
        yield return new WaitForSeconds(3);

        popOutWindow.SetActive(false);
    }







}
