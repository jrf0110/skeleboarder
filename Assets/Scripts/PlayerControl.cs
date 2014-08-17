﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	[HideInInspector]
	public bool facingRight 		= true;     // For determining which way the player is currently facing.

	[HideInInspector]
	public bool jumping     		= false;    // Condition for whether the player should jump.

	public bool allowMoveJumps  = false; 		// Whether or not to allow movement while jumping

	public float moveForce  		= 100f;     // Amount of force added to move the player left and right.
	public float maxSpeed   		= 1f;       // The fastest the player can travel in the x axis.
	public float jumpForce  		= 100f;    // Amount of force added when the player jumps.

	private bool grounded   		= false;    // Whether or not the player is grounded.
	private Transform groundCheck;					// A position marking where to check if the player is grounded.
	private Animator anim;									// Reference to the player's animator component.

	void Awake (){
		groundCheck = transform.Find("GroundCheck");
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		// The player is grounded if a linecast to the
		// groundcheck position hits anything on the ground layer
		grounded = Physics2D.Linecast(
			transform.position,
			groundCheck.position,
			1 << LayerMask.NameToLayer("Ground")
		);

		if ( Input.GetButtonDown("Jump") && grounded ){
			jumping = true;
		}
	}

	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");

		// If the player is changing direction
		// (h has a different sign to velocity.x)
		// or hasn't reached maxSpeed yet
		if ( grounded || allowMoveJumps )
		if ( Mathf.Abs( h * rigidbody2D.velocity.x ) < maxSpeed ){
			rigidbody2D.AddForce( Vector2.right * h * moveForce );
		}

		if ( Mathf.Abs( h * rigidbody2D.velocity.x ) > maxSpeed ){
			rigidbody2D.velocity = new Vector2(
				( rigidbody2D.velocity.x < 0 ? -1 : 1 ) * maxSpeed
			, rigidbody2D.velocity.y
			);
		}

		// Correct character direction
		if ( h > 0 && !facingRight ){
			TurnRight();
		} else if ( h < 0 && facingRight ){
			TurnLeft();
		}

		// Handle jumping
		if ( jumping ){
			print("Is Jumping");
			rigidbody2D.AddForce( new Vector2( 0f, jumpForce ) );
			jumping = false;
		}
	}

	void TurnRight (){
		if ( facingRight ) return;

		facingRight = true;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void TurnLeft (){
		if ( !facingRight ) return;

		facingRight = false;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
