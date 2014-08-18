using UnityEngine;
using System.Collections;

public class TitleScreenMusicManager : MonoBehaviour {


	void Start () {
		// 1. create and return the Intro Scene music audio - this doesn't play the sound, but it provides a gameobject and a handle to it
		
		if (BaseSoundManager.level1MusicObject != null)
		{
			StartCoroutine (AudioHelper.FadeAudioObject (BaseSoundManager.level1MusicObject, -0.25f));
		}
		
		
		if (BaseSoundManager.titleMusicObject == null)
		{
			//FADE VERSIONS
			BaseSoundManager.titleMusicObject = AudioHelper.CreateGetFadeAudioObject 
				(BaseSoundManager.baseSoundManagerInstance.titleMusic, true, null, "Audio-TitleMusic");
			
			// 2. play the clip with fade in
			StartCoroutine (AudioHelper.FadeAudioObject (BaseSoundManager.titleMusicObject, 0.25f));
		}
		
	}

}
