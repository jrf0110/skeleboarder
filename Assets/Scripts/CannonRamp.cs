using UnityEngine;
using System.Collections;

public class CannonRamp : MonoBehaviour {

	private Rigidbody2D otherRigidbody;
	public float platformForceY;
	public float platformForceX;

	// Use this for initialization
	void Start () {
	
		//thePlayersRigidbody = 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D ( Collider2D col ){
		if (col.gameObject.tag == "Skateboard")
		{
			AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.cannonRamp, 1f, "cannonRampSoundObj");

			otherRigidbody = col.gameObject.GetComponent<Rigidbody2D>();
			otherRigidbody.rigidbody2D.AddForce(new Vector2(platformForceX, platformForceY));


		}
	}


}
