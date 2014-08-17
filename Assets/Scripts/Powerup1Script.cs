using UnityEngine;
using System.Collections;

public class Powerup1Script : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.getItem, 1f, "getItemSoundObject" );
			Destroy(gameObject);
		}
	}
}
