using UnityEngine;
using System.Collections;

public class PlayerGrind : MonoBehaviour {
  public float rotation;
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

    transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
  }

  public void leaveGrindMode(){
    if ( !isGrinding ){
      return;
    }

    Debug.Log("Leaving Grinding");
    isGrinding = false;

    transform.rotation = Quaternion.AngleAxis(0, Vector3.up);

    // transform.rotation.Set(
    //   transform.rotation.x
    // , 0
    // , transform.rotation.z
    // , transform.rotation.w
    // );
  }
}
