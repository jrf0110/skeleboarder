using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour {

	ParticleSystem particle;
	
	// Use this for initialization
	void Start () {
		particle = this.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!particle.isPlaying) {
			Destroy(gameObject);
		}
	}
}
