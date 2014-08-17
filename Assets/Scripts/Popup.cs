using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	//private float upwardsness = 1;

	// Use this for initialization
	void Start () {
		//transform.position = transform.position + new Vector3 (0, 1);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = transform.position + new Vector3 (0, Mathf.Lerp (0, 1, Time.deltaTime), 0);

		Destroy(gameObject,1f);
	}
}
