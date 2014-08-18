using UnityEngine;
using System.Collections;

public class BoneText : MonoBehaviour {

	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.FindGameObjectWithTag ("Skateboard").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.guiText.text = playerHealth.health + "/" + playerHealth.maxHealth;
	
	}
}
