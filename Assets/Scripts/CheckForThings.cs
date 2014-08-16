using UnityEngine;
using System.Collections;

public class CheckForThings : MonoBehaviour {

	public GameObject soundHolder;

	// Use this for initialization
	void Start () 
	{
		if(GameObject.FindGameObjectWithTag("SoundHolder") == null)
		{
			Instantiate(soundHolder);
		}

	}
}
