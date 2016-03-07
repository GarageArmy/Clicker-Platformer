using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody2D playerBody;

	public float moveSpeed;
	public float jumpHeight;

	private bool moveRight = false; 
	private bool moveLeft = false;

	private bool grounded = true;
	private bool doubleJump = false;
	public LayerMask ground;
	public float groundCheckRadius;
	public Transform groundCheck;

	private Animator anim;
	// Use this for initialization
	void Start (){
		playerBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, ground);
		anim.SetBool ("grounded", grounded);
	}

	void Update (){


		if (moveRight) { 
			playerBody.velocity = new Vector2 (moveSpeed, playerBody.velocity.y);
			anim.SetBool ("move", true);
			transform.localScale = new Vector3 (1, 1, 1);
		}
		else if (moveLeft) {
			playerBody.velocity = new Vector2 (-moveSpeed, playerBody.velocity.y);
			anim.SetBool ("move", true);
			transform.localScale = new Vector3 (-1, 1, 1);
		} else anim.SetBool ("move", false);
	}

	public void onClickRight () {
		moveRight = !moveRight; 
	}
	public void onClickLeft () {
		moveLeft = !moveLeft; 
	}

	public void jump (){
		if (grounded) {
			doubleJump = false;
			playerBody.velocity = new Vector2 (playerBody.velocity.x, jumpHeight);
		}
		if (!grounded && doubleJump == false) {
			doubleJump = true;
			playerBody.velocity = new Vector2 (playerBody.velocity.x, jumpHeight);
		}
	}

}
