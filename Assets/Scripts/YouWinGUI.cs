using UnityEngine;
using System.Collections;

public class YouWinGUI : MonoBehaviour {

	private WinField winField;
	public GameObject WinGUIHolder;

	private bool madeWinGUI;
	

	// Use this for initialization
	void Start () {
		winField = GameObject.FindGameObjectWithTag ("WinField").GetComponent<WinField>();
		madeWinGUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (winField.victory) {
		if(!madeWinGUI)
			{

				//Instantiate(WinGUIHolder);
				WinGUIHolder.SetActive(true);
				madeWinGUI = true;
			}
		}


		//If you collide with the winField
		
	}
}
