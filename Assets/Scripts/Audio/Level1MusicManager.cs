using UnityEngine;
using System.Collections;

public class Level1MusicManager : MonoBehaviour {
	


	// Use this for initialization
	void Start () {
		// 1. create and return the Intro Scene music audio - this doesn't play the sound, but it provides a gameobject and a handle to it

		if (BaseSoundManager.titleMusicObject != null)
		{
			StartCoroutine (AudioHelper.FadeAudioObject (BaseSoundManager.titleMusicObject, -0.25f));
		}


		if (BaseSoundManager.level1MusicObject == null)
		{
		//FADE VERSIONS
		BaseSoundManager.level1MusicObject = AudioHelper.CreateGetFadeAudioObject 
			(BaseSoundManager.baseSoundManagerInstance.level1Music, true, BaseSoundManager.baseSoundManagerInstance.fadeClip, "Audio-Level1Music");

//		//NON FADE VERSIONS
//		BaseSoundManager.level1MusicObject = AudioHelper.CreateGetFadeAudioObject 
//			(BaseSoundManager.baseSoundManagerInstance.level1Music, true, null, "Audio-Level1Music");

		// 2. play the clip with fade in
		StartCoroutine (AudioHelper.FadeAudioObject (BaseSoundManager.level1MusicObject, 0.25f));
		}

	}
}
