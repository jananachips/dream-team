using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempGround : MonoBehaviour {
    public float destroyAfter = 3f;
    public BlinkObject blinkObject;

	void Start () {
        blinkObject = FindObjectOfType<BlinkObject>();
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            blinkObject.DoBlinkObject();
            StartCoroutine(DisableAfter(destroyAfter));
        }

    }


    IEnumerator DisableAfter(float time)
    {

        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}
