//////////////////////////////////////////////////////////////
// GameCSharp_PowerUpStatus.cs
// 
// GameCSharp_PowerUpStatus haves all PowerUps information and status
//////////////////////////////////////////////////////////////
/// 
using UnityEngine;
using System.Collections;

public class GameCSharp_PowerUpStatus : MonoBehaviour
{
	private int PlayPosX;
	private int PwrUpPosX;
	private int PlayPosY;
	private int PwrUpPosY;
	private Transform thisTransform;
	
	void  Start ()
	{

	}
	
	void  Update ()
	{
		GameObject PlayStat = GameObject.Find ("Obj_Player");
		PlayPosX = (int)PlayStat.GetComponent<GameCSharp_PlayerStatus> ().transform.position.x;
		PlayPosY = (int)PlayStat.GetComponent<GameCSharp_PlayerStatus> ().transform.position.y;
		PwrUpPosX = (int)transform.position.x;
		PwrUpPosY = (int)transform.position.y;
		if ((PlayPosX == PwrUpPosX) && (PlayPosY == PwrUpPosY))
		{
			if (GameObject.Find ("Obj_Sword") == gameObject)
			{
				//print("Funkar");
				PlayStat.GetComponent<GameCSharp_PlayerStatus> ().Sword (true);
				Destroy (GameObject.Find ("Obj_Sword"));
			}
			else if (GameObject.Find ("Obj_DoubleJump") == gameObject)
			{
				//print("Funkar");
				PlayStat.GetComponent<GameCSharp_PlayerStatus> ().DoubleJumP (true);
				Destroy (GameObject.Find ("Obj_DoubleJump"));
			}
			else if (GameObject.Find ("Obj_Key") == gameObject)
			{
				//print("Funkar");
				PlayStat.GetComponent<GameCSharp_PlayerStatus> ().Key (true);
				Destroy (GameObject.Find ("Obj_Key"));
			}
			else
			{
				print (gameObject);
			}
		}
	}
}