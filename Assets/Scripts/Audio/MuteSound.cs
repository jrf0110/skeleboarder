using UnityEngine;
using System.Collections;

public class MuteSound : MonoBehaviour {

	private bool mute;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M))
		{
			mute = !mute;
			AudioListener.pause = mute;
		}
	}
}
