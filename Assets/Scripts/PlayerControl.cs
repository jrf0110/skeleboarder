using UnityEngine;
using System.Collections;

public delegate void PlayerActionHandler( object sender );

public class PlayerControl : MonoBehaviour {
	[HideInInspector]
	public bool facingRight 		= true;     // For determining which way the player is currently facing.

	[HideInInspector]
	public bool jumping     		= false;    // Condition for whether the player should jump.

	// Amount of control the player has of dx in the air
	public float jumpMoveFactor = 0.1f;

	public float moveForce  		= 100f;     // Amount of force added to move the player left and right.
	public float maxSpeed   		= 10f;      // The fastest the player can travel in the x axis.
	public float jumpForce  		= 100f;     // Amount of force added when the player jumps.
	public float rotationSpeed 	= 300.0f;   // Rotation speed

	private bool grounded   		= false;    // Whether or not the player is grounded.
	//private Animator anim;								// Reference to the player's animator component.
	private Transform groundCheck;					// A position marking where to check if the player is grounded.
	private PlayerGrind pGrind;

	// Events
	public event PlayerActionHandler PlayerBeforeJump;
	public event PlayerActionHandler PlayerAfterJump;

	//Animation Stuff
	private tk2dSpriteAnimator playerAnimator;

	//ForDeath
	private PlayerHealth playerHealth;
	
	void Awake (){
		groundCheck = transform.Find("GroundCheck");
		pGrind = GetComponent<PlayerGrind>();
		//anim = GetComponentInChildren<Animator>();

		//Animation
		playerAnimator = GetComponentInChildren<tk2dSpriteAnimator>();

	}

	void Start()
	{
		playerHealth = GameObject.FindGameObjectWithTag ("Skateboard").GetComponent<PlayerHealth>();
	}

	void Update () {
		if (!playerHealth.isActive) {
			transform.position = Vector2.zero;
				}

		// The player is grounded if a linecast to the
		// groundcheck position hits anything on the ground layer
		grounded = Physics2D.Linecast(
			transform.position,
			groundCheck.transform.position,
			1 << LayerMask.NameToLayer("Ground")
		);

		if ( Input.GetButtonDown("Jump") && grounded ){
			jumping = true;
		}

		UpdateAnimation ();
	}

	void FixedUpdate () {
		if (playerHealth.isActive) {
						float h = Input.GetAxis ("Horizontal");
						float v = Input.GetAxis ("Vertical");

						// If the player is changing direction
						// (h has a different sign to velocity.x)
						// or hasn't reached maxSpeed yet
						if (h * rigidbody2D.velocity.x < maxSpeed) {
								rigidbody2D.AddForce (
				new Vector2 (
					Mathf.Cos (transform.rotation.x), Mathf.Sin (transform.rotation.y)
								) * h * moveForce * (!grounded ? jumpMoveFactor : 1)
								);
						}

						if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed) {
								rigidbody2D.velocity = new Vector2 (
				(rigidbody2D.velocity.x < 0 ? -1 : 1) * maxSpeed
			, rigidbody2D.velocity.y
								);
						}

						// Correct character direction
						if (h > 0 && !facingRight) {
								TurnRight ();
						} else if (h < 0 && facingRight) {
								TurnLeft ();
						}

						// Handle jumping
						if (jumping) {
								if (PlayerBeforeJump != null) {
										PlayerBeforeJump (this);
								}

								AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.jump, 1f, "jumpSndObj");
								rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
								jumping = false;

								if (PlayerAfterJump != null) {
										PlayerAfterJump (this);
								}
						}

						// Handle rotation
						// Do not rotate while grinding
						if (!pGrind.isGrinding () && (v > 0 || v < 0)) {
								transform.Rotate (
				0
			, 0
			, v * rotationSpeed * Time.deltaTime * (facingRight ? 1 : -1)
								);
						}
				}
	}

	void TurnRight (){
		if ( facingRight ) return;

		MessageFlasher.Flash("Turned Right!");
		facingRight = true;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void TurnLeft (){
		if ( !facingRight ) return;

		MessageFlasher.Flash("Turned Left!");
		facingRight = false;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void UpdateAnimation(){
		if ( playerAnimator == null ) return;

		float horizontalInput = Input.GetAxis("Horizontal");

		if ( grounded && horizontalInput == 0 ){
			playerAnimator.Play("Idle");
		} else if ( !grounded && rigidbody2D.velocity.y != 0 ){
			playerAnimator.Play("Jump");
		} else if ( !grounded && rigidbody2D.velocity.x != 0 ){
			playerAnimator.Play("Idle");
		} else if (grounded &&  Mathf.Abs( horizontalInput) > 0){
			playerAnimator.Play("Kicking");
		}
	}

	

}
