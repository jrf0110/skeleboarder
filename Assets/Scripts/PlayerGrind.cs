using UnityEngine;
using System.Collections;

public class PlayerGrind : MonoBehaviour {
  public float rotation;
  public float maxSpeed = 10f;
  public float baseSpeed = 5f;
  public float speedFactor = 0.3f;
  public bool grinding;
  private PlayerCode player;

	// Use this for initialization
	void Start () {
    player = GetComponent<Skate>();
    grinding = false;
    player.PlayerJump += new PlayerActionEventHandler( OnPlayerJump );
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

    transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);

    updatePlayerVelocity();
  }

  public void leaveGrindMode(){
    if ( !isGrinding() ){
      return;
    }

    Debug.Log("Leaving Grinding");
    grinding = false;

    transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
  }
}
