using UnityEngine;
using System.Collections;

public class PlayerCode : MonoBehaviour {

	//Movement Stuff
  private float horizontalInput, verticalInput;
	public float maxSpeed = 10f;
	public float maxSpeedHolder;
	private bool horizontalInputing;
	private bool canHorizontalInput = true;
	public bool timeToDisableHorizontalInput;
	private float t = 0;

	//Jumping
	public bool touchingPlatform;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 300f;
	public bool dubbaJump;
	//private bool thisSoundHasPlayed;

	//Rotation Stuff
	public float rotationSpeed = 150.0f;

	//Life Stuff
  public bool isActive;
	public int health = 100;

	//Animation Stuff
	//private tk2dSpriteAnimator playerAnimator;
	
    // Use this for initialization
    void Start()
    {
		maxSpeedHolder = maxSpeed;

		isActive = true;

		//Animation
		//playerAnimator = GetComponent<tk2dSpriteAnimator>();
    }
	

	//==================UPDATE METHODS======================
//	void UpdateAnimation()
//	{
//		if(horizontalInput == 0 || rigidbody2D.velocity == Vector2.zero) 
//		{
//			playerAnimator.Play("Idle");
//		}
//		
//		if (!touchingPlatform && rigidbody2D.velocity.y > 0)
//		{
//			playerAnimator.Play("Jump");
//		}
//		
//		else if (!touchingPlatform && rigidbody2D.velocity.y < 0)
//		{
//			playerAnimator.Play("Falling");
//		}
//	}

	void Jumping()
	{
		if ((touchingPlatform || !dubbaJump))
		{	
			if(Input.GetButtonDown("Jump"))
			{
				//if(!thisSoundHasPlayed)
				//{
					AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.jump, 1f, "JumpSound" );
				//	thisSoundHasPlayed = true;
				//}

				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
				rigidbody2D.AddForce(new Vector2(0, jumpForce));

				if(!dubbaJump && !touchingPlatform)
				{
					dubbaJump = true;
				}
			}

		}
	}

	void TemporarilyDisableHorizontalInput()
	{
		//maxSpeed = 1.5f;
		canHorizontalInput = false;

		if(!canHorizontalInput)
		{
			t += Time.deltaTime;
			if(t >= .75f)
			{	
				canHorizontalInput= true;
				timeToDisableHorizontalInput = false;
				t = 0f;
			}
		}
	}
	
	//==================UPDATE!!!!======================

	//==================================================

	//==================================================
	void Update () 
  {
  	//print(rigidbody2D.velocity.x + ", " + rigidbody2D.velocity.y);
		if (isActive)
    {
			if(horizontalInput != 0) horizontalInputing = true;
			else horizontalInputing = false;

			if(timeToDisableHorizontalInput) TemporarilyDisableHorizontalInput();

			horizontalInput = Input.GetAxis("Horizontal");
			verticalInput = Input.GetAxis("Vertical");

			//UpdateAnimation();

			Jumping();
		}
	}
	
	//==================END=UPDATE======================

	//==================================================

	//==================================================

	void FixedUpdate()
	{	
		//print ("fixed update: " + Time.deltaTime);
		if(isActive)
		{
			touchingPlatform = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

			if(horizontalInputing && canHorizontalInput) rigidbody2D.velocity = new Vector2(horizontalInput*maxSpeed, rigidbody2D.velocity.y);

			if(touchingPlatform) 
			{
				dubbaJump = false;
			}

			transform.Rotate(0, 0, verticalInput * rotationSpeed * Time.deltaTime);
		}
	}

	public void bumpHorizontal( float x ){
		Debug.Log("Bump Back: " + x);
		rigidbody2D.AddForce( new Vector2( x, 0 ) );
	}
}  //Class
