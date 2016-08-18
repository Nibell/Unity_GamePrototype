//////////////////////////////////////////////////////////////
// GameJava_EnemyAI.js
//
// GameJava_EnemyAI creates a AI for the object.
//////////////////////////////////////////////////////////////

#pragma strict

@script RequireComponent(CharacterController)

private var WalkSpeed : float = 3;

private var TimeToNewDir : int;
private var NextTimeToNewDir : float = 0.0;

private var DirMove : float = 1;
private var TurnNow = false;

private var AttackDist : float = 2;
private var DetRang : float = 15;
private var TargDir : Vector3;
private var TargDist : float;

private var EnemyTag;
private var EnemyFlying : boolean = false;
private var EnemyTrack : boolean = false;

private var PlayTarg : Transform;
private var thisTransform : Transform;
private var character : CharacterController;
private var velocity : Vector3;
private var movement = Vector3.zero;

function Start() 
{
	// Cache component lookup at startup instead of doing this every frame	
	thisTransform = GetComponent(Transform);
	character = GetComponent(CharacterController);
	
	TimeToNewDir = Random.Range(1,5);
	
	if(!PlayTarg)
	{
		PlayTarg = GameObject.Find("Obj_Player").transform;
	}
	
	if(!EnemyTag)
	{
		EnemyTag = gameObject.tag;
	}
}

function Update()
{
	thisTransform.position.z = 0;
	movement = Vector3.right * WalkSpeed * DirMove;
	
	if(PlayTarg)
	{
		TargDir = PlayTarg.position - thisTransform.position;
       	TargDist = TargDir.magnitude;
        
        if(EnemyTag == "Grounded")
        {
			if(character.isGrounded)
			{
				velocity = Vector3.zero;
				TrackPlayer();
        	}
			else
			{
				velocity.y += Physics.gravity.y * Time.deltaTime;
			}
			Movement();
		}
		
		if(EnemyTag == "Flying")
		{
			EnemyFlying = true;
			TrackPlayer();
			Movement();
		}
	}
	
	// Actually move the character
	character.Move(movement);
}

function Idle()
{
	if(Time.time > NextTimeToNewDir)
	{
		TimeToNewDir = Random.Range(1,5);
		NextTimeToNewDir = Time.time + TimeToNewDir;
		TurnNow=true;
	}
	if(TurnNow)
	{
		TurnNow=false;
		DirMove *= -1;
	}
}

function Movement()
{
		if(EnemyFlying == true && EnemyTrack == false)
        {
        	velocity.y = Random.Range(-2,3);
        }
        else if(EnemyFlying == false)
        {
        	movement += Physics.gravity;
        }
		movement += velocity;
		movement *= Time.deltaTime;
}

function TrackPlayer()
{
	if (!Physics.Raycast(thisTransform.position, TargDir, DetRang))
	{
		Idle();
	}
	else
	{ 
		EnemyTrack = true;
		
   		if (TargDist <= AttackDist)
   		{
        	var PlayDamange = GameObject.Find("Obj_Player");
			PlayDamange.GetComponent(GameJava_PlayerStatus).Damange();
    	}
    	else
    	{
      		if(PlayTarg.position.x < thisTransform.position.x)
			{
    			DirMove = -1;
    		}
    		else if(PlayTarg.position.x > thisTransform.position.x)
			{
    			DirMove = 1;
    		}
    		
    		if(EnemyFlying == true)
    		{
    			if(PlayTarg.position.y < thisTransform.position.y)
				{
    				velocity.y = -1;
    			}
    			else if(PlayTarg.position.y > thisTransform.position.y)
				{
    				velocity.y = 1;
    			}
    		}
    	}
    }
}