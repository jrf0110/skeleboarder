using UnityEngine;
using System.Collections;

public class RailGrind : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnCollisionEnter2D ( Collision2D collision ){
    if ( collision.gameObject.tag == "Player" ){
      PlayerGrind player = collision.gameObject.GetComponent<PlayerGrind>();
      player.enterGrindMode();
    }
  }

  void OnCollisionExit2D ( Collision2D collision ){
    if ( collision.gameObject.tag == "Player" ){
      PlayerGrind player = collision.gameObject.GetComponent<PlayerGrind>();
      player.leaveGrindMode();
    }
  }
}
