using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _test_playerMovement : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed;


	void Start () {
		
	}
    	
    //from the another code file
	void Update () {
        float moveInput = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(speed * moveInput * Time.deltaTime, 0, 0);
        rb.position = rb.position + new Vector2(speed * moveInput * Time.deltaTime, 0);

        


	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("on ground");
        }
    }
}
