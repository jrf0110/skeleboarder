using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {


	private string levelName;
	
	// Use this for initialization
	void Start () {

		levelName = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
		


		if(Input.GetKeyDown(KeyCode.R))
		   {

			Application.LoadLevel(levelName);
		}
		
	}
}
