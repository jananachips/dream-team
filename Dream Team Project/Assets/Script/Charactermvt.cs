using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermvt : MonoBehaviour
{
	//making variables 
	public Rigidbody2D myRigidbody;
	public float speed = 5;
	public float jumpForce = 8;

	bool isGround = true;
	private float horizontalInput;
	
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D variable)
	{
		Debug.Log("gothere");
		if (variable.gameObject.tag == "Ground")
			isGround = true;

	}
	
	// Update is called once per frame
	void Update () {
		//get user input
		horizontalInput = Input.GetAxis("Horizontal");
		transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

		if (Input.GetButtonDown("Jump") && isGround == true)
		{
			Debug.Log("inair");
			myRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			isGround = false;
		}

	}
}
