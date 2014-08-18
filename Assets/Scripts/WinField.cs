using UnityEngine;
using System.Collections;

public class WinField : MonoBehaviour {

	public bool victory;

	void OnTriggerEnter2D ( Collider2D col ){
		if (col.gameObject.tag == "Skateboard")
		{
			AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.secret, 1f, "winLevelSoundObj");
			
			victory = true;
		}
	}
}
