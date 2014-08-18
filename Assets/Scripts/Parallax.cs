using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	//private PlayerControl playerControl;
	//private Rigidbody2D playerRigidbody;
	private GameObject skateboard;
	public float offsetX = 0.85f;
	public float offsetY = 0.97f;
	public Vector2 startingPosition;

	void Start()
	{
		skateboard = GameObject.FindGameObjectWithTag ("Skateboard");
		startingPosition = transform.position;
		//playerControl = GameObject.FindGameObjectWithTag ("Skateboard").GetComponent<PlayerControl> ();
		//playerRigidbody = GameObject.FindGameObjectWithTag ("Skateboard").GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
//		transform.position = new Vector3(transform.position.x - playerRigidbody.velocity.x * offsetX,
//		                                 transform.position.y + playerRigidbody.velocity.y * offsetY,
//		                                 0);

//		rigidbody2D.velocity = new Vector2(-playerRigidbody.velocity.x * offsetX,
//			                               -playerRigidbody.velocity.y * offsetY);

		transform.position = startingPosition + new Vector2(skateboard.transform.position.x * offsetX,
		                                 skateboard.transform.position.y * offsetY);
	}


	

}
