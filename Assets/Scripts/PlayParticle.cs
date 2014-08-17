using UnityEngine;
using System.Collections;

public class PlayParticle : MonoBehaviour {

	public GameObject particle;

	public void PlayBoneExplosion()
	{
		Instantiate (particle);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.B)) {
			PlayBoneExplosion();
		}
	}
	
}
