using UnityEngine;
using System.Collections;

public class GameplayGUI : MonoBehaviour {
	
	public tk2dUIItem exitBtn;

	void OnEnable()
	{
		if (exitBtn) {exitBtn.OnClick += LoadLevel1;}
	}


	private void LoadLevel1()
	{
		Application.LoadLevel("TitleScreen");
	}
}
