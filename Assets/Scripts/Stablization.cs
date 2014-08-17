using UnityEngine;
using System.Collections;

public class Stablization : MonoBehaviour {

	//Movement Stuff
	private float horizontalInput, verticalInput;
	public float maxSpeed = 10f;
	public float maxSpeedHolder;
	private bool horizontalInputing;
	private bool canHorizontalInput = true;
	public bool timeToDisableHorizontalInput;
	private float t = 0;
	//private PlayerGrind grinder;
	
	// Previous horizontal input from last update
	private float prevHInput;
	
	//Jumping
	public bool touchingPlatform;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 300f;
	public bool dubbaJump;

	//Physics stuff
	Ray ray = new Ray(); 
	RaycastHit hit; 
	Vector3 axis; 
	float angle;
	public Transform centerOfMass;
	
	//Sound Stuff
	private bool thisSoundHasPlayed;
	
	//Rotation Stuff
	public float rotationSpeed = 300.0f;
	
	// Use this for initialization
	void Start()
	{
		maxSpeedHolder = maxSpeed;

		rigidbody2D.centerOfMass = centerOfMass.position - new Vector3(0,.5f,0);
		
		//grinder = GetComponent<PlayerGrind>();
	}

	
	void Jumping()
	{
		if ((touchingPlatform || !dubbaJump))
		{	
			if(Input.GetButtonDown("Jump"))
			{
				AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.jump, 1f, "JumpSound" );
				
				//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
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

	void RotateToPerpendicular()
	{
		ray.origin = gameObject.transform.position;
		ray.direction = -gameObject.transform.up;
		
		Physics.Raycast(ray, out hit);
		
		axis = Vector3.Cross(-gameObject.transform.forward,-hit.normal);
		//print (axis);
		if(axis != Vector3.zero)
		{
			angle = Mathf.Atan2(Vector3.Magnitude(axis), Vector3.Dot(-gameObject.transform.forward,-hit.normal));
			//print("angle");
			gameObject.transform.Rotate(axis,angle);
		}
	}
	
	
	//==================UPDATE!!!!======================
	
	//==================================================
	
	//==================================================
	void Update () 
	{
		if(horizontalInput != 0) horizontalInputing = true;
		else horizontalInputing = false;

		horizontalInputing = false;
		
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		
		//Jumping();

		RotateToPerpendicular ();
	}
	
	//==================END=UPDATE======================
	
	//==================================================
	
	//==================================================
	
	void FixedUpdate()
	{	
			touchingPlatform = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			
			if(horizontalInputing && canHorizontalInput) rigidbody2D.velocity = new Vector2(horizontalInput*maxSpeed, rigidbody2D.velocity.y);
			
			if(touchingPlatform) 
			{
				dubbaJump = false;
			}
			
			transform.Rotate(0, 0, verticalInput * rotationSpeed * Time.deltaTime);
		
//		if ( Input.GetAxis("Horizontal") < 0 && prevHInput > 0 ){
//			TurnLeft();
//		} else if ( Input.GetAxis("Horizontal") > 0 && prevHInput < 0 ) {
//			TurnRight();
//		}
//		
//		prevHInput = horizontalInput;
	}
	
//	public void TurnLeft(){
//		transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
//	}
//	
//	public void TurnRight(){
//		transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
//	}
}
