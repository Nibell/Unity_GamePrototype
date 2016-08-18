//////////////////////////////////////////////////////////////
// CubeJava_Gravity.js
//
// CubeJava_Gravity creates a 2D control scheme where gravity is applied
//////////////////////////////////////////////////////////////

#pragma strict

@script RequireComponent(CharacterController)

private var character : CharacterController;
private var velocity : Vector3;
private var movement = Vector3.zero;

function Start()
{
	// Cache component lookup at startup instead of doing this every frame
	character = GetComponent(CharacterController);
}

function OnEndGame()
{
	// Don't allow any more control changes when the game ends
	this.enabled = false;
}

function Update()
{
	// Check for jump
	if(character.isGrounded)
	{
		velocity = Vector3.zero;
	}
	
	else
	{
		// Apply gravity to our velocity to diminish it over time
		velocity.y += Physics.gravity.y * Time.deltaTime;
	}
		
	movement += velocity;	
	movement += Physics.gravity;
	movement *= Time.deltaTime;
	
	// Actually move the character	
	character.Move(movement);
}