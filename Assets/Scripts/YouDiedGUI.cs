using UnityEngine;
using System.Collections;

public class YouDiedGUI : MonoBehaviour {

	private PlayerHealth playerHealth;
	public GameObject youDiedGUIHolder;
	private bool madeGUI;
	
	// Use this for initialization
	void Start () {
		playerHealth = GameObject.FindGameObjectWithTag ("Skateboard").GetComponent<PlayerHealth>();
		madeGUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerHealth.health <= 0) 
		{
			//print ("you died!");
			//youDiedGUIHolder.SetActive(true);
			if(!madeGUI)
			{
				//Instantiate(youDiedGUIHolder);
				youDiedGUIHolder.SetActive(true);
				madeGUI = true;

				//button on this gui can reset level
			}
		}
		
	}
}
