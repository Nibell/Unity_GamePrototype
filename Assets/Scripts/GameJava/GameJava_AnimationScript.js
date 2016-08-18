//////////////////////////////////////////////////////////////
// GameJava_AnimationScript.js
//
// GameJava_AnimationScript creates a 2D animation for the object
//////////////////////////////////////////////////////////////

#pragma strict

// This script must be attached to a GameObject that has a Animator
private var old_pos : float;

private var anim : Animator;
private var ObjectTag;

private var facingRight : boolean = false;
private var character : CharacterController;
private var thisTransform : Transform;

function Start()
{
	// Animator component lookup at startup instead of doing this every frame
	old_pos = transform.position.x;		
	anim = GetComponent("Animator");
	character = GetComponent(CharacterController);
	
	if(!ObjectTag)
	{
		ObjectTag = gameObject.tag;
	}
}

function Update()
{
	if(old_pos < transform.position.x)
	{
		if(facingRight)
		{
			Flip();
		}
	}
	
	else if(old_pos > transform.position.x)
	{
		if(!facingRight)
		{
			Flip();
		}
	}
		
	if((old_pos < transform.position.x) || (old_pos > transform.position.x))
	{
		//print("moving right");
		anim.SetFloat("Speed",Mathf.Abs(1));
	}
	else
	{
		anim.SetFloat("Speed",Mathf.Abs(0));
	}
	
	if(ObjectTag == "Player")
	{
		if(character.isGrounded)
		{
			anim.SetBool("InAir",false);
		}
		
		else if(!character.isGrounded)
		{
			if((old_pos < transform.position.x) || (old_pos > transform.position.x))
			{
				//print("moving right");
				anim.SetBool("InAir",true);
			}
			else
			{
				anim.SetBool("InAir",false);
			}
		}
	}
	old_pos = transform.position.x;
}

function Flip()
{
    facingRight = !facingRight;
    var theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
}