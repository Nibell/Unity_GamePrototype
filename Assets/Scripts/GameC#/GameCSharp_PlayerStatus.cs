//////////////////////////////////////////////////////////////
// GameCSharp_PlayerStatus.cs
// 
// GameCSharp_PlayerStatus haves all Player information and status
//////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GameCSharp_PlayerStatus : MonoBehaviour 
{
	// This script must be attached to a GameObject that has a PlayerControlls
	private int TimeToNewDam = 2;
	private float NextTimeToNewDam = 0.0f;
	private int HearthStatus = 13;

	private Animator anim;
	private bool  HaveSwordStatus = false;
	private bool  HaveDoubleJumPStatus  = false;
	private bool  DamNow = false;
	private bool  KeyStatus = false;
	
	private Transform PlayerTransform;
	
	void  Start()
	{	
		anim = GetComponent<Animator>();
	}
	
	void  Update()
	{
		//print(PlayerPosition);
		if(HaveSwordStatus==true)
		{
			anim.SetBool("HaveSword",true);
		}
		
		if(HearthStatus <= 1)
		{
			Application.LoadLevel("AppMeny");
			//Destroy(gameObject);
		}
		if((Time.time > NextTimeToNewDam) && (DamNow == false))
		{
			gameObject.renderer.material.color = Color.white;
		}
	}
	
	public void Damange()
	{
		if(Time.time > NextTimeToNewDam)
		{
			NextTimeToNewDam = Time.time + TimeToNewDam;
			DamNow=true;
			gameObject.renderer.material.color = Color.white;
		}
		if(DamNow)
		{
			DamNow=false;
			HearthStatus -= 1;
			//print(HearthStatus);
			gameObject.renderer.material.color = Color.red;
		}
	}
	
	public int Health ()
	{
		return HearthStatus;
	}
	
	public bool Key(bool KeyMethod)
	{
		if(KeyMethod == true)
		{
			KeyStatus = true;
		}
		else if(KeyMethod == false)
		{
			return KeyStatus;
		}
		return false;	
	}
	
	public bool DoubleJumP(bool DoubleJumPMethod)
	{
		if(DoubleJumPMethod == true)
		{
			HaveDoubleJumPStatus = true;
		}
		else if(DoubleJumPMethod == false)
		{
			return HaveDoubleJumPStatus;
		}
		return false;
	}
	
	public bool Sword(bool SwordMethod)
	{
		if(SwordMethod == true)
		{
			HaveSwordStatus = true;
		}
		else if(SwordMethod == false)
		{
			return HaveSwordStatus;
		}
		return false;
	}
}