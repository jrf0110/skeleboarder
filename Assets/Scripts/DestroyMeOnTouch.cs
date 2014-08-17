using UnityEngine;
using System.Collections;

public class DestroyMeOnTouch : MonoBehaviour {

	public bool giveMeTimeToDie;

	private PolygonCollider2D thisObjectsCollider;

	void Start()
	{
		thisObjectsCollider = gameObject.GetComponent<PolygonCollider2D> ();
	}

	void OnTriggerEnter2D ( Collider2D col ){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Skateboard")
		{
			if(!giveMeTimeToDie) Destroy (gameObject);

			else
			{
				//print ("asdf");
				//collider.isTrigger = true;
				Destroy (gameObject, 1f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Skateboard")
		{
			//print ("colliders");
			if(!giveMeTimeToDie) Destroy (gameObject);
			
			else
			{
				//print ("asdf");
				thisObjectsCollider.isTrigger = true;
				Destroy (gameObject, 1f);
			}
		}
	}
}
