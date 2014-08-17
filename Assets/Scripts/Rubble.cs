using UnityEngine;
using System.Collections;

public class Rubble : MonoBehaviour {
  public float MaxSpeed = 3f;
  private float OldMaxSpeed;

  void OnTriggerEnter2D ( Collider2D collider ){
    if ( collider.tag == "Player" ){
      PlayerControl pControl = collider.GetComponent<PlayerControl>();
      OldMaxSpeed = pControl.maxSpeed;
      pControl.maxSpeed = MaxSpeed;
    }
  }

  void OnTriggerExit2D ( Collider2D collider ){
    // Restore max speed
    if ( collider.tag == "Player" ){
      print("restore to " + OldMaxSpeed);
      PlayerControl pControl = collider.GetComponent<PlayerControl>();
      pControl.maxSpeed = OldMaxSpeed;
    }
  }
}
