using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _test_playerMovement : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 5;
    public float jumpForce = 8;

    private bool isGround = true;

	void Start () {
		
	}
    	
    //from the another code file
	void Update () {

        


	}

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(speed * moveInput * Time.deltaTime, 0, 0);
        rb.position = rb.position + new Vector2(speed * moveInput * Time.deltaTime, 0);

        if(Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGround = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }


}
