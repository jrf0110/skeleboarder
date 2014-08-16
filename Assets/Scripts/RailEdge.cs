using UnityEngine;
using System.Collections;

public class RailEdge : MonoBehaviour {

  public int damage = 10;
  private PlayerCode player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnCollisionEnter2D ( Collision2D collision ){
    if ( collision.gameObject.tag == "Player" ){
      player = collision.gameObject.GetComponent<PlayerCode>();
      player.health -= damage;
      Debug.Log("Player! Health: " + player.health);
    }
  }
}
