using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MovAndAnimation: MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 5;
    public float jumpForce = 8;

    private bool isGround = true;
    private Animator playerAnimator;
    private Transform playerTransfrom;
    //private Vector3 originalScale;
    //private float originalScaleX;

	void Start () {
        playerAnimator = GetComponent<Animator>();
        playerTransfrom = GetComponent<Transform>();

        //originalScaleX = transform.localScale.x;
	}
    	
	void Update () {

        


	}

    private void FixedUpdate()
    {
        //playerTransfrom.

        float moveInput = Input.GetAxis("Horizontal");
        float curHorizontalSpeed = moveInput * speed;
        rb.position = rb.position + new Vector2(speed * moveInput * Time.deltaTime, 0);

        if(moveInput < 0 && transform.localScale.x > 0)
        {
            //transform.localScale = new Vector3(transform.localScale.x * moveInput, transform.localScale.y, transform.localScale.z);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }else if(moveInput > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        //trigger the playerwalk animation
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(curHorizontalSpeed)); 

        /*
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.position = rb.position + new Vector2(speed * -1 * Time.deltaTime, 0);

        }else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            rb.position = rb.position + new Vector2(speed * 1 * Time.deltaTime, 0);
        }
        */


        if(Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGround = false;
            //playerAnimator.SetBool("PlayerJump", true);

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }


}
