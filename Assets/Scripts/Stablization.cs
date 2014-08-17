using UnityEngine;
using System.Collections;

public class Stablization : MonoBehaviour {
	
	//Movement Stuff
	private float verticalInput;
	
	//Physics stuff
	Ray ray = new Ray(); 
	RaycastHit hit; 
	Vector3 axis; 
	float angle;
	//public Transform centerOfMass;
	public float stablizationAmount = -.5f;

	//Rotation Stuff
	public float rotationSpeed = 300.0f;
	
	// Use this for initialization
	void Start()
	{
		//rigidbody2D.centerOfMass = centerOfMass.position - new Vector3(0,stablizationAmount,0);
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
		rigidbody2D.centerOfMass = new Vector3(0,stablizationAmount,0);

		verticalInput = Input.GetAxis("Vertical");

		RotateToPerpendicular ();
	}

	void FixedUpdate()
	{	
			transform.Rotate(0, 0, verticalInput * rotationSpeed * Time.deltaTime);
	}
}
