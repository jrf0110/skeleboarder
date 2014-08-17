using UnityEngine;
using System.Collections;

public class Stablization : MonoBehaviour {
	//Physics stuff
	Ray ray = new Ray(); 
	RaycastHit hit; 
	Vector3 axis; 
	float angle;
	public float stablizationAmount = .5f;
	private PlayerGrind pGrind;

	void Start()
	{
		rigidbody2D.centerOfMass = new Vector3(0,stablizationAmount,0);
		pGrind = GetComponent<PlayerGrind>();
	}



	/*
	cast a ray from player.transform down.
	take the inverse(-) of the normal of the surface you hit use those to find the axis of rotation and the angle,
	this will rotate the character so his feet are always parallel with the ground.
	*/
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

	//TRY AN SLERP FOR GRADUAL ROTATION
	
	void Update () 
	{
		if ( !pGrind.isGrinding() ){
			RotateToPerpendicular ();
		}
	}
}
