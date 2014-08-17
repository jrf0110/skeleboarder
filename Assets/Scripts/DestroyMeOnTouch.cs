using UnityEngine;
using System.Collections;

public class DestroyMeOnTouch : MonoBehaviour {

	void OnTriggerEnter2D ( Collider2D col ){

		if (col.gameObject.tag == "Player") {

						Destroy (gameObject);
				}
	}
}
