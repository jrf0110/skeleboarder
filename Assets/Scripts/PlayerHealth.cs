using UnityEngine;
using System.Collections;

public delegate void PlayerHealthEventHandler( object sender, System.EventArgs e );

public class PlayerHealth : MonoBehaviour {
  public float health               = 100f;   // The player's health
  public float maxHealth            = 100f;   // The player's max health
  public float repeatDmgPeriod      = 2f;     // Number of seconds between damage
	public bool isActive;
  
  private float lastHitTime;                  // The time at which the player was last hit.

	public GameObject boneAuraHolder;

  void Awake (){
    lastHitTime = -repeatDmgPeriod;
		isActive = true;
  }

	void Update()
	{
		if (health < 0) {
			isActive = false;
				}
		}

  void OnCollisionEnter2D ( Collision2D col ){
    // Does the collider have the PlayerDamager component?
    PlayerDamager giver = col.gameObject.GetComponent<PlayerDamager>();
    if ( giver == null ) return;

		if (col.gameObject.tag == "Powerup1") {
			print ("hit a powerup!");
						TakeDamage (giver.damageAmount);
				} else {
						// Ensure we can still damage
						if (Time.time <= lastHitTime + repeatDmgPeriod)
								return;

						TakeDamage (giver.damageAmount);
						lastHitTime = Time.time;
				}
  }

  void OnTriggerEnter2D ( Collider2D col ){

		if (col.gameObject.tag == "DeathField") {
			health = 0;
				
		}

    // Does the collider have the PlayerDamager component?
    PlayerDamager giver = col.GetComponent<PlayerDamager>();
    if ( giver == null ) return;
    
    // Ensure we can still damage
		if (col.gameObject.tag == "Powerup1") {
			print ("hit a powerup!");
			TakeDamage (giver.damageAmount);
		} else {
			// Ensure we can still damage
			if (Time.time <= lastHitTime + repeatDmgPeriod)
				return;
			
			TakeDamage (giver.damageAmount);
			lastHitTime = Time.time;
		}
    
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
  	print("Adjusting health by: " + h );
  	IncHealth( h );
		if (h < 0) {
			AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.gotHit, 1f, "collideSoundObject");
			Instantiate (boneAuraHolder, transform.position, Quaternion.identity);
		} else {
			AudioHelper.CreatePlayAudioObject (BaseSoundManager.baseSoundManagerInstance.linkGotItem, 1f, "gotHealthSoundObject");
		}
	}

	public void Heal( float h ){
		IncHealth( +h );
	}
}
