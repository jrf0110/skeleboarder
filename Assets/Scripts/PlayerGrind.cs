using UnityEngine;
using System.Collections;

public class PlayerGrind : MonoBehaviour {
  public float rotation;
  public float maxSpeed;
  public float baseSpeed;
  public float speedFactor;
  public bool grinding;
  private Quaternion prevRotation;

	// Use this for initialization
	void Start () {
    // player = GetComponent<PlayerCode>();
    // player.PlayerJump += new PlayerActionEventHandler( OnPlayerJump );
    grinding = false;
  }
  
  public void FixedUpdate () {
    if ( isGrinding() ){
      updatePlayerVelocity();
    }
	}

  void OnPlayerJump( object sender, System.EventArgs e ){
    print("Grind: Player Jump");
  }

  public bool isGrinding(){
    return grinding;
  }

  public void updatePlayerVelocity(){
    float dx = rigidbody2D.velocity.x;

    rigidbody2D.velocity = new Vector2(
      Mathf.Clamp(
        ( ( dx >= 0 ? 1 : -1 ) * baseSpeed + dx ) * speedFactor
      , -maxSpeed
      , maxSpeed
      )
    , 0
    );
  }

  public void enterGrindMode(){
    if ( isGrinding() ){
      return;
    }

    Debug.Log("Is Grinding");
    grinding = true;

    float dx = rigidbody2D.velocity.x;
    prevRotation = transform.rotation;

    transform.rotation = Quaternion.AngleAxis(
      ( dx >= 0 ? 1 : -1 ) * rotation
    , Vector3.up
    );

    updatePlayerVelocity();
  }

  public void leaveGrindMode(){
    if ( !isGrinding() ){
      return;
    }

    Debug.Log("Leaving Grinding");
    grinding = false;

    transform.rotation = prevRotation;
  }
}
