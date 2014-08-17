using UnityEngine;
using System.Collections;

public class Stablization : MonoBehaviour {

<<<<<<< HEAD
	//Movement Stuff
	private float verticalInput;


=======
	public bool touchingPlatform;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;
>>>>>>> 533cf8e56f98bdf6b59e099827b56ed94d93109b

	//Physics stuff
	Ray ray = new Ray(); 
	RaycastHit hit; 
	Vector3 axis; 
	float angle;
	//public Transform centerOfMass;
	public float stablizationAmount = .5f;
	

	
	//Rotation Stuff
	public float rotationSpeed = 300.0f;
	
	// Use this for initialization
	void Start()
	{
<<<<<<< HEAD


		//rigidbody2D.centerOfMass = centerOfMass.position - new Vector3(0,stablizationAmount,0);
		

	}

	

	

=======
		rigidbody2D.centerOfMass = centerOfMass.position - new Vector3(0,.5f,0);
	}
>>>>>>> 533cf8e56f98bdf6b59e099827b56ed94d93109b

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
	
	void Update () 
	{
<<<<<<< HEAD
		rigidbody2D.centerOfMass = new Vector3(0,stablizationAmount,0);

		verticalInput = Input.GetAxis("Vertical");
		
=======
>>>>>>> 533cf8e56f98bdf6b59e099827b56ed94d93109b
		RotateToPerpendicular ();
	}

	void FixedUpdate()
	{	
<<<<<<< HEAD
			transform.Rotate(0, 0, verticalInput * rotationSpeed * Time.deltaTime);
=======
		touchingPlatform = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
>>>>>>> 533cf8e56f98bdf6b59e099827b56ed94d93109b
	}
}
