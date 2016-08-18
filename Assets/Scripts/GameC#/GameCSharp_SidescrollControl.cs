//////////////////////////////////////////////////////////////
// GameCSharp_SidescrollControl.cs
//
// GameCSharp_SidescrollControl creates a 2D control scheme where the left
// pad is used to move the character, and the right pad is used
// to make the character jump.
//////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class GameCSharp_SidescrollControl : MonoBehaviour
{
	// This script must be attached to a GameObject that has a CharacterController
	public GameCSharp_Joystick moveTouchPad;
	public GameCSharp_Joystick jumpTouchPad;
	public GameCSharp_Joystick attackTouchPad;

	private float WalkSpeed = 4;
	private float jumpSpeed = 23;
	private float inAirMultiplier = 0.20f;					// Limiter for ground speed while jumping
	
	private bool  PlayJumpStatus = false;
	private int DoubleJump;
	
	private bool  PlaySwordStatus = false;
	
	private Transform thisTransform;
	private CharacterController character;
	private Vector3 velocity;						// Used for continuing momentum while in air
	private bool canJump = true;
	private bool canAttack = true;
	private Vector3 movement = Vector3.zero;
	
	void  Start (){
		// Cache component lookup at startup instead of doing this every frame		
		thisTransform = GetComponent<Transform>();
		character = GetComponent<CharacterController>();
		
		// Move the character to the correct start position in the level, if one exists
		GameObject spawn = GameObject.Find("PlayerSpawn");
		if(spawn)
		{
			thisTransform.position = spawn.transform.position;
		}
	}
	
	void  OnEndGame (){
		// Disable joystick when the game ends	
		moveTouchPad.enabled = false;
		jumpTouchPad.enabled = false;
		attackTouchPad.enabled = false;
		
		// Don't allow any more control changes when the game ends
		this.enabled = false;
	}
	
	void  Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("AppMeny");
		}
		
		movement = Vector3.right * WalkSpeed * moveTouchPad.position.x;
		
		//thisTransform.position.z = 0;
		
		GameObject PlayJumpStat= GameObject.Find("Obj_Player");
		PlayJumpStatus = PlayJumpStat.GetComponent<GameCSharp_PlayerStatus>().DoubleJumP(false);
		
		// Check for jump
		if(character.isGrounded)
		{
			velocity = Vector3.zero;
			DoubleJump = 0;
			Jump();
		}
		
		else if((character.isGrounded==false) && (PlayJumpStatus==true))
		{
			Jump();
			
			// Apply gravity to our velocity to diminish it over time
			velocity.y += Physics.gravity.y * Time.deltaTime;
			// Adjust additional movement while in-air
			movement.x *= inAirMultiplier;
		}
		
		else
		{
			// Apply gravity to our velocity to diminish it over time
			velocity.y += Physics.gravity.y * Time.deltaTime;
			// Adjust additional movement while in-air
			movement.x *= inAirMultiplier;
		}
		
		movement += velocity;	
		movement += Physics.gravity;
		movement *= Time.deltaTime;
		
		// Actually move the character	
		character.Move(movement);
		
		GameObject PlaySwordStat= GameObject.Find("Obj_Player");
		PlaySwordStatus = PlaySwordStat.GetComponent<GameCSharp_PlayerStatus>().Sword(false);
		if(PlaySwordStatus==true)
		{
			bool attack= false;
			
			if(!attackTouchPad.IsFingerDown())
			{
				canAttack = true;
			}
			
			if(canAttack && attackTouchPad.IsFingerDown())
			{
				attack = true;
				canAttack = false;
			}
			
			if(attack)
			{
				print("Attack");
				Attack();
			}
		}
	}
	
	void  Jump (){
		bool jump= false;
		if(DoubleJump < 2)
		{
			if(!jumpTouchPad.IsFingerDown())
			{
				canJump = true;
			}
			
			if(canJump && jumpTouchPad.IsFingerDown())
			{
				jump = true;
				canJump = false;
			}
			
			if(jump)
			{
				DoubleJump++;
				// Apply the current movement to launch velocity
				velocity = character.velocity;
				velocity.y = jumpSpeed;
			}
		}
	}
	
	void  Attack (){
		
	}
}