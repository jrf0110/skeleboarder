using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour {

	public tk2dUIItem startBtn;
	public tk2dUIItem optBtn;
	public tk2dUIItem exitBtn;

	void OnEnable()
	{
		if (startBtn) {startBtn.OnClick += LoadLevel1;}
		if (optBtn) {startBtn.OnClick += LoadLevel1;}
		if (exitBtn) {startBtn.OnClick += LoadLevel1;}
	}


	private void LoadLevel1()
	{
		Application.LoadLevel("Level1");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
