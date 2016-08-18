//////////////////////////////////////////////////////////////
// GameCSharp_EnemyAI.cs
//
// GameCSharp_EnemyAI creates a AI for the object.
//////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class GameCSharp_EnemyAI : MonoBehaviour
{
	private float WalkSpeed = 3;
	private int TimeToNewDir;
	private float NextTimeToNewDir = 0.0f;
	private float DirMove = 1;
	private bool TurnNow = false;
	private float AttackDist = 2;
	private float DetRang = 15;
	private Vector3 TargDir;
	private float TargDist;
	private string EnemyTag = "";
	private bool EnemyFlying = false;
	private bool EnemyTrack = false;
	private Transform PlayTarg;
	private Transform thisTransform;
	private CharacterController character;
	private Vector3 velocity;
	private Vector3 movement = Vector3.zero;
    
	void Start ()
	{
		// Cache component lookup at startup instead of doing this every frame  
		thisTransform = GetComponent<Transform> ();
		character = GetComponent<CharacterController> ();
        
		TimeToNewDir = Random.Range (1, 5);
        
		if (!PlayTarg)
		{
			PlayTarg = GameObject.Find ("Obj_Player").transform;
		}
        
		if ("" == EnemyTag)
		{
			EnemyTag = gameObject.tag;
		}
	}
    
	void Update ()
	{
		//thisTransform.position.z = 0;
		movement = Vector3.right * WalkSpeed * DirMove;
        
		if (PlayTarg)
		{
			TargDir = PlayTarg.position - thisTransform.position;
			TargDist = TargDir.magnitude;
            
			if (EnemyTag == "Grounded")
			{
				if (character.isGrounded)
				{
					velocity = Vector3.zero;
					TrackPlayer ();
				}
				else
				{
					velocity.y += Physics.gravity.y * Time.deltaTime;
				}
				Movement ();
			}
            
			if (EnemyTag == "Flying")
			{
				EnemyFlying = true;
				TrackPlayer ();
				Movement ();
			}
		}
        
		// Actually move the character
		character.Move (movement);
	}
    
	void Idle ()
	{
		if (Time.time > NextTimeToNewDir)
		{
			TimeToNewDir = Random.Range (1, 5);
			NextTimeToNewDir = Time.time + TimeToNewDir;
			TurnNow = true;
		}
		if (TurnNow)
		{
			TurnNow = false;
			DirMove *= -1;
		}
	}
    
	void Movement ()
	{
		if (EnemyFlying == true && EnemyTrack == false)
		{
			velocity.y = Random.Range (-2, 3);
		}
		else if (EnemyFlying == false)
		{
			movement += Physics.gravity;
		}
		movement += velocity;
		movement *= Time.deltaTime;
	}
    
	void TrackPlayer ()
	{
		if (!Physics.Raycast (thisTransform.position, TargDir, DetRang))
		{
			Idle ();
		}
		else
		{ 
			EnemyTrack = true;
            
			if (TargDist <= AttackDist)
			{
				GameObject PlayDamange = GameObject.Find ("Obj_Player");
				PlayDamange.GetComponent<GameCSharp_PlayerStatus> ().Damange ();
			}
			else
			{
				if (PlayTarg.position.x < thisTransform.position.x)
				{
					DirMove = -1;
				}
				else if (PlayTarg.position.x > thisTransform.position.x)
				{
					DirMove = 1;
				}
				if (EnemyFlying == true)
				{
					if (PlayTarg.position.y < thisTransform.position.y)
					{
						velocity.y = -1;
					}
					else if (PlayTarg.position.y > thisTransform.position.y)
					{
						velocity.y = 1;
					}
				}
			}
		}
	}
}