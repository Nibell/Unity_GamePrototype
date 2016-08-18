//////////////////////////////////////////////////////////////
// GameJava_SidescrollControl.js
//
// GameJava_SidescrollControl creates a 2D control scheme where the left
// pad is used to move the character, and the right pad is used
// to make the character jump.
//////////////////////////////////////////////////////////////

#pragma strict

@script RequireComponent(CharacterController)

// This script must be attached to a GameObject that has a CharacterController
var moveTouchPad : GameJava_Joystick;
var jumpTouchPad : GameJava_Joystick;
var attackTouchPad : GameJava_Joystick;
	
private var WalkSpeed : float = 4;
private var jumpSpeed : float = 23;
private var inAirMultiplier : float = 0.20;					// Limiter for ground speed while jumping

private var PlayJumpStatus : boolean = false;
private var DoubleJump : int;

private var PlaySwordStatus : boolean = false;

private var thisTransform : Transform;
private var character : CharacterController;
private var velocity : Vector3;						// Used for continuing momentum while in air
private var canJump  : boolean = true;
private var canAttack  : boolean = true;
private var movement = Vector3.zero;

function Start()
{
	// Cache component lookup at startup instead of doing this every frame		
	thisTransform = GetComponent(Transform);
	character = GetComponent(CharacterController);

	// Move the character to the correct start position in the level, if one exists
	var spawn = GameObject.Find("PlayerSpawn");
	if(spawn)
	{
		thisTransform.position = spawn.transform.position;
	}
}

function OnEndGame()
{
	// Disable joystick when the game ends	
	moveTouchPad.Disable();
	jumpTouchPad.Disable();
	attackTouchPad.Disable();

	// Don't allow any more control changes when the game ends
	this.enabled = false;
}

function Update()
{
	if(Input.GetKeyDown(KeyCode.Escape))
	{
		Application.LoadLevel("AppMeny");
	}
	
	movement = Vector3.right * WalkSpeed * moveTouchPad.position.x;
	
	thisTransform.position.z = 0;
	
	var PlayJumpStat = GameObject.Find("Obj_Player");
	PlayJumpStatus = PlayJumpStat.GetComponent(GameJava_PlayerStatus).DoubleJumP(false);
	
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
	
	var PlaySwordStat = GameObject.Find("Obj_Player");
	PlaySwordStatus = PlaySwordStat.GetComponent(GameJava_PlayerStatus).Sword(false);
	if(PlaySwordStatus==true)
	{
		var attack = false;
		
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

function Jump()
{
	var jump = false;
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

function Attack()
{

}