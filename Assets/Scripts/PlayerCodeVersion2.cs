using UnityEngine;
using System.Collections;

//public delegate void PlayerActionEventHandler(object sender, System.EventArgs e);

public class PlayerCodeVersion2 : MonoBehaviour {

	//Life Stuff
  	public bool isActive;
	public int health = 100;

	//Animation Stuff
	//private tk2dSpriteAnimator playerAnimator;

//	// Events
//	public event PlayerActionEventHandler PlayerJump;
	
    // Use this for initialization
    void Start()
    {
			isActive = true;

			//Animation
			//playerAnimator = GetComponent<tk2dSpriteAnimator>();
    }
	

	//==================UPDATE METHODS======================
//	void UpdateAnimation()
//	{
//		if(horizontalInput == 0 || rigidbody2D.velocity == Vector2.zero) 
//		{
//			playerAnimator.Play("Idle");
//		}
//		
//		if (!touchingPlatform && rigidbody2D.velocity.y > 0)
//		{
//			playerAnimator.Play("Jump");
//		}

	//		if (!touchingPlatform && rigidbody2D.velocity.x > 0)
	//		{
	//			playerAnimator.Play("Cruise");
	//		}
//		
//		else if (!touchingPlatform && rigidbody2D.velocity.y < 0)
//		{
//			playerAnimator.Play("Falling");
//		}
//	}

	//==================UPDATE!!!!======================

	//==================================================

	//==================================================
	void Update () 
  	{
		if (isActive)
    	{
		}
	}
	
	//==================END=UPDATE======================

	//==================================================

	//==================================================
	

}  //Class
