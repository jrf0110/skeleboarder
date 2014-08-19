using UnityEngine;
using System.Collections;

public class StayInPlace : MonoBehaviour {

	Vector2 spawnPosition;		

	// Use this for initialization
	void Start () {
		spawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = spawnPosition;
	}
}
