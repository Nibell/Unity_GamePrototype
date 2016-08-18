//////////////////////////////////////////////////////////////
// GameJava_PlayerStatus.js
// 
// GameJava_PlayerStatus haves all Player information and status
//////////////////////////////////////////////////////////////

#pragma strict

// This script must be attached to a GameObject that has a PlayerControlls
private var TimeToNewDam : int = 2;
private var NextTimeToNewDam : float = 0.0;
private var HearthStatus : int = 13;

private var anim : Animator;
private var HaveSwordStatus: boolean = false;
private var HaveDoubleJumPStatus : boolean  = false;
private var DamNow : boolean = false;
private var KeyStatus : boolean = false;

private var PlayerTransform : Transform;

function Start ()
{	
	anim = GetComponent("Animator");
}

function Update ()
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

function Damange()
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

function Health() : int
{
	return HearthStatus;
}

function Key(KeyMethod : boolean) : boolean
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

function DoubleJumP(DoubleJumPMethod : boolean) : boolean
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

function Sword(SwordMethod : boolean) : boolean
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