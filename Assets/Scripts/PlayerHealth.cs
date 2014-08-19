using UnityEngine;
using System.Collections;

public delegate void PlayerHealthEventHandler( object sender, System.EventArgs e );

public class PlayerHealth : MonoBehaviour {
  public float health               = 100f;   // The player's health
  public float maxHealth            = 100f;   // The player's max health
  public float invincibilityTime      = 2f;     // Number of seconds between damage
	private bool invincible;
	private float t = 0;
	public bool isActive;
  
  private float lastHitTime;                  // The time at which the player was last hit.

	public GameObject boneAuraHolder;

  	void Awake ()
	{
		isActive = true;
	}

	void Update()
	{
		if (health < 0) {
			isActive = false;
				}

		if (invincible) 
		{
			t += Time.deltaTime;
			if(t >= invincibilityTime)
			{
				invincible = false;
				t = 0;
			}
		}
	}

  void OnCollisionEnter2D ( Collision2D col ){
    // Does the collider have the PlayerDamager component?
    PlayerDamager giver = col.gameObject.GetComponent<PlayerDamager>();
    if ( giver == null ) return;

		if (col.gameObject.tag == "Powerup1") 
		{
			//print ("hit a powerup!");
			TakeDamage (giver.damageAmount);
		} 
		else 
		{
			if(!invincible)
			{
				TakeDamage (giver.damageAmount);
				invincible = true;
			}
		}
  }

  void OnTriggerEnter2D ( Collider2D col )
	{
		if (col.gameObject.tag == "DeathField") 
		{
			health = 0;
			isActive = false;
		}
    
	// Does the collider have the PlayerDamager component?
    PlayerDamager giver = col.GetComponent<PlayerDamager>();
    if ( giver == null ) return;
    
    // Ensure we can still damage
		if (col.gameObject.tag == "Powerup1") 
		{
			TakeDamage (giver.damageAmount);
		} 

		else 
		{
			// Ensure we can still damage
			if (!invincible)
			{
				print ("invincible");
				TakeDamage (giver.damageAmount);
				invincible = true;
			}
		}
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
