using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollider_Trigger : MonoBehaviour {

    public Vector3 parentOriScale;
    public BoxCollider2D myCollider;

    public float exitDelay = 0.1f;
    public float pressedSizeY = 0.01f;
    private float repeatTime = 10;
    //shrink too fast will make player "exit trigger", so I will to kind of slow down
    private float shrinkRate;
    private bool hasOneItem = false;
    private Collider2D currentItem_Collider;
    public bool isButtonPressed = false;

	void Start () {
        parentOriScale = transform.parent.localScale;
        myCollider = GetComponent<BoxCollider2D>();

        shrinkRate = (parentOriScale.y - pressedSizeY) / repeatTime;

	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("collided in " + otherCollider.tag);
        if(otherCollider.tag != "Ground" && !hasOneItem)
        {
            hasOneItem = true;
            isButtonPressed = true;
            currentItem_Collider = otherCollider;
            StartCoroutine(SizeShrinking(repeatTime));
        }
        
    }

    IEnumerator SizeShrinking(float repeatTime_temp)
    {
        for(int i = 0; i < repeatTime_temp; i++)
        {
            transform.parent.localScale = new Vector3(parentOriScale.x, transform.parent.localScale.y - shrinkRate, parentOriScale.z);
            yield return new WaitForSeconds(0.01f);
        }
    }


    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        //make sure the previous item exit
        if(otherCollider.transform.tag != "Ground" && currentItem_Collider.name == otherCollider.name)
        {
            Debug.Log("someone exit: " + otherCollider.tag);
            hasOneItem = false;
            isButtonPressed = false;
            StartCoroutine(WaitTimeFor(exitDelay));
        }
    }


    IEnumerator WaitTimeFor(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        transform.parent.localScale = parentOriScale;
    }


}
