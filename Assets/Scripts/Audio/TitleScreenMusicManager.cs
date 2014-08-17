using UnityEngine;
using System.Collections;

public class TitleScreenMusicManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		// 1. create and return the Intro Scene music audio - this doesn't play the sound, but it provides a gameobject and a handle to it

		//NON FADE VERSIONS
		BaseSoundManager.titleMusicObject = AudioHelper.CreateGetFadeAudioObject 
			(BaseSoundManager.baseSoundManagerInstance.titleMusic, true, null, "Audio-TitleMusic");

		// 2. play the clip with fade in
		StartCoroutine (AudioHelper.FadeAudioObject (BaseSoundManager.titleMusicObject, 0.25f));
	}
}
