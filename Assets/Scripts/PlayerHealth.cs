using UnityEngine;
using System.Collections;

public delegate void PlayerHealthEventHandler( object sender, System.EventArgs e );

public class PlayerHealth : MonoBehaviour {
  public float health               = 100f;   // The player's health
  public float maxHealth            = 100f;   // The player's max health
  public float repeatDmgPeriod      = 2f;     // Number of seconds between damage

  private float lastHitTime = 0;                  // The time at which the player was last hit.

  void Awake (){

  }

  void OnCollisionEnter2D ( Collision2D col ){
    // Does the collider have the PlayerDamager component?
    PlayerDamager giver = col.gameObject.GetComponent<PlayerDamager>();
    if ( giver == null ) return;

    // Ensure we can still damage
//    if ( Time.time <= lastHitTime + repeatDmgPeriod ) return;

    TakeDamage( giver.damageAmount );
    lastHitTime = Time.time;
  }

  public void SetHealth( float h ){
    health = Mathf.Min( h, maxHealth );
  }

  public void IncHealth( float h ){
    SetHealth( health + h );
  }

  public void TakeDamage( float h ){
    print("Taking Damage: " + h );
    IncHealth( -h );
	AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.gotHit, 1f, "collideSoundObject" );
  }

	void OnTriggerEnter2D ( Collider2D col ){
		// Does the collider have the PlayerDamager component?
		PlayerDamager giver = col.GetComponent<PlayerDamager>();
		if ( giver == null ) return;
		
		// Ensure we can still damage
		//if ( Time.time <= lastHitTime + repeatDmgPeriod ) return;
		
		TakeDamage( giver.damageAmount );
		lastHitTime = Time.time;
		}


}
