using UnityEngine;
using System.Collections;

public class Stablization : MonoBehaviour {
	//Physics stuff
	Ray ray = new Ray(); 
	RaycastHit hit; 
	Vector3 axis; 
	float angle;
	public float stablizationAmount = .5f;

	
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
		RotateToPerpendicular ();
	}
}
