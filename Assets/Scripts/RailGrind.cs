using UnityEngine;
using System.Collections;

public class RailGrind : MonoBehaviour {
  void OnCollisionEnter2D ( Collision2D collision ){
    PlayerGrind player = collision.gameObject.GetComponent<PlayerGrind>();
    print("Collision");
    if ( player != null ){
      player.enterGrindMode();
    }
  }

  void OnCollisionExit2D ( Collision2D collision ){
    PlayerGrind player = collision.gameObject.GetComponent<PlayerGrind>();
    if ( player != null ){
      player.leaveGrindMode();
    }
  }
}
