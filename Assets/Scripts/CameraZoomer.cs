using UnityEngine;
using System.Collections;

public class CameraZoomer : MonoBehaviour {

	//public float minimumZoom;

	private tk2dCamera thisCamera;

	public float maxZoom = .3f;
	//public float minZoom = 1;

	//public GameObject skateboard;
	private PlayerControl playerControl;

	void Start()
	{
		thisCamera = gameObject.GetComponent<tk2dCamera> ();
		playerControl = GameObject.FindGameObjectWithTag("Skateboard").GetComponent<PlayerControl> ();

//		maxZoom = 1 - maxZoom;
//		minZoom = 1 - minZoom;

		//minimumZoom = thisCamera.ZoomFactor;
	}

	// Update is called once per frame
	void Update () {
	
		//if (playerControl.speed < playerControl.maxSpeed || playerControl.speed < 0) 

		//if (thisCamera.ZoomFactor < (minZoom +1) || thisCamera.ZoomFactor > (maxZoom+1)) 
		//{
			//print (Mathf.Abs (playerControl.speed) * maxZoom / playerControl.maxSpeed);
			//print (1 - Mathf.Abs (playerControl.speed) / playerControl.maxSpeed);
			thisCamera.ZoomFactor = Mathf.Lerp (thisCamera.ZoomFactor, 
			                                    //1 - Mathf.Abs (playerControl.speed) / playerControl.maxSpeed, 
			                                    //((1-maxZoom)/playerControl.maxSpeed) * Mathf.Abs (playerControl.speed),
			                                    1-Mathf.Abs (Mathf.Clamp (playerControl.speed, -playerControl.maxSpeed,playerControl.maxSpeed)) * (1-maxZoom)/playerControl.maxSpeed,
			                                    Time.deltaTime*.25f);
		//}

		//THE FASTER YOU GO, THE MORE THE CAMERA ZOOMS OUT
	}
}
