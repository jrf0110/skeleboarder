using UnityEngine;
using System.Collections;

public class RailEdge : MonoBehaviour {

  public int damage = 10;
  public float bumpBack = 100;

  void OnCollisionEnter2D ( Collision2D collision ){
    // Damage and bump back player when they hit the edge
    if ( collision.gameObject.tag == "Player" ){
      PlayerHealth pHealth = collision.gameObject.GetComponent<PlayerHealth>();
      pHealth.TakeDamage( -damage );
      collision.gameObject.rigidbody2D.AddForce(
        new Vector2( -bumpBack, 0 )
      );
    }
  }
}
