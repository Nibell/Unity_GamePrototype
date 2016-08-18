//////////////////////////////////////////////////////////////
// CubeJava_Gravity.js
//
// CubeJava_Gravity creates a 2D control scheme where gravity is applied
//////////////////////////////////////////////////////////////

#pragma strict

@script RequireComponent(CharacterController)

private var jumpSpeed = 20;
private var timer = 0.0;
private var character : CharacterController;
private var velocity : Vector3;
private var movement = Vector3.zero;

function Start()
{
	// Cache component lookup at startup instead of doing this every frame
	character = GetComponent(CharacterController);
}

function Update()
{
	 // Check for jump
    if(character.isGrounded)
    {
        velocity = Vector3.zero;
        timer += Time.deltaTime;
        if (timer > 0.10)
        {
            BallJump();
            timer = 0.0;
        }
    } else
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

function BallJump()
{
    // Apply the current movement to launch velocity
    velocity = character.velocity;
    velocity.y = jumpSpeed;
}