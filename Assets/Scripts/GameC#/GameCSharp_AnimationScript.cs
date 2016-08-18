//////////////////////////////////////////////////////////////
// GameCSharp_AnimationScript.cs
//
// GameCSharp_AnimationScript creates a 2D animation for the object
//////////////////////////////////////////////////////////////
	
using UnityEngine;
using System.Collections;
	
public class GameCSharp_AnimationScript : MonoBehaviour
{
	// This script must be attached to a GameObject that has a Animator
	private float old_pos;
	
	private Animator anim;
	private string ObjectTag = "";
	
	private bool facingRight = false;
	private CharacterController character;
	private Transform thisTransform;
	
	void  Start (){
		// Animator component lookup at startup instead of doing this every frame
		old_pos = transform.position.x;		
		anim = GetComponent<Animator>();
		character = GetComponent<CharacterController>();
		
		if("" ==ObjectTag)
		{
			ObjectTag = gameObject.tag;
		}
	}
	
	void  Update (){
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
	
	void  Flip (){
		facingRight = !facingRight;
		Vector3 theScale= transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}