//////////////////////////////////////////////////////////////
// GameJava_PowerUpStatus.js
// 
// GameJava_PowerUpStatus haves all PowerUps information and status
//////////////////////////////////////////////////////////////

#pragma strict

private var PlayPosX : int;
private var PwrUpPosX : int;
private var PlayPosY : int;
private var PwrUpPosY : int;
private var thisTransform : Transform;

function Start ()
{
}

function Update ()
{
	var PlayStat = GameObject.Find("Obj_Player");
	PlayPosX = PlayStat.GetComponent(GameJava_PlayerStatus).transform.position.x;
	PlayPosY = PlayStat.GetComponent(GameJava_PlayerStatus).transform.position.y;
	PwrUpPosX = transform.position.x;
	PwrUpPosY = transform.position.y;
	if((PlayPosX == PwrUpPosX) && (PlayPosY == PwrUpPosY))
	{
		if(gameObject.Find("Obj_Sword") == gameObject)
		{
			//print("Funkar");
			PlayStat.GetComponent(GameJava_PlayerStatus).Sword(true);
			Destroy(gameObject.Find("Obj_Sword"));
		}
		else if(gameObject.Find("Obj_DoubleJump") == gameObject)
		{
			//print("Funkar");
			PlayStat.GetComponent(GameJava_PlayerStatus).DoubleJumP(true);
			Destroy(gameObject.Find("Obj_DoubleJump"));
		}
		else if(gameObject.Find("Obj_Key") == gameObject)
		{
			//print("Funkar");
			PlayStat.GetComponent(GameJava_PlayerStatus).Key(true);
			Destroy(gameObject.Find("Obj_Key"));
		}
		else
		{
			print(gameObject);
		}
	}
}