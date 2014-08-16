using UnityEngine;
using System.Collections;

public class RailEdge : MonoBehaviour {

  public int damage = 10;
  public float bumpBack = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnCollisionEnter2D ( Collision2D collision ){
    if ( collision.gameObject.tag == "Player" ){
      PlayerCode player = collision.gameObject.GetComponent<PlayerCode>();
      player.health -= damage;
      player.bumpHorizontal( -bumpBack );
    }
  }
}
