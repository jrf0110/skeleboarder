using UnityEngine;
using System.Collections;

public class Powerup1Script : MonoBehaviour {

	//Animation Stuff
	private tk2dSpriteAnimator anim;

	//Goodies
	public tk2dSprite goodie;

	void Start()
	{
		//Animation
		anim = GetComponentInChildren<tk2dSpriteAnimator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{


			AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.getItem, 1f, "getItemSoundObject" );
			anim.Play("chestOpen");
			Instantiate(goodie, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject, .25f);
		}
	}
}
