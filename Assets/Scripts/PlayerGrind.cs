using UnityEngine;
using System.Collections;

public class PlayerGrind : MonoBehaviour {
  public float rotation = 50;
  public bool isGrinding;

	// Use this for initialization
	void Start () {
	 isGrinding = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void enterGrindMode(){
    if ( isGrinding ){
      return;
    }

    Debug.Log("Is Grinding");
    isGrinding = true;

    transform.rotation.Set(
      transform.rotation.x
    , rotation
    , transform.rotation.z
    , transform.rotation.w
    );
  }

  public void leaveGrindMode(){
    if ( !isGrinding ){
      return;
    }

    Debug.Log("Leaving Grinding");
    isGrinding = false;

    transform.rotation.Set(
      transform.rotation.x
    , 0
    , transform.rotation.z
    , transform.rotation.w
    );
  }
}
