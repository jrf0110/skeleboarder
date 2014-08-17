using UnityEngine;
using System.Collections;

public class Stablization : MonoBehaviour {

	public bool touchingPlatform;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;

	//Physics stuff
	Ray ray = new Ray(); 
	RaycastHit hit; 
	Vector3 axis; 
	float angle;
	public Transform centerOfMass;
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.centerOfMass = centerOfMass.position - new Vector3(0,.5f,0);
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
	
	void Update () 
	{
		RotateToPerpendicular ();
	}

	void FixedUpdate()
	{	
		touchingPlatform = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	}
}
