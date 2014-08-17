﻿using UnityEngine;
using System.Collections;

public class Obstacle1Script : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.gotHit, 1f, "collideSoundObject" );

			//Do some damage stuff

			//Turn on the particle effect

			//Destroy(gameObject);
		}
	}
}
