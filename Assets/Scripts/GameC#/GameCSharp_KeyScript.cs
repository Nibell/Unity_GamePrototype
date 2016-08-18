//////////////////////////////////////////////////////////////
// GameCSharp_KeyScript.cs
//
// GameCSharp_KeyScript creates a 2D animation for the GuiTexture
//////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GameCSharp_KeyScript : MonoBehaviour 
{
	public Texture2D Key1 = null;
	public Texture2D Key2 = null;
	
	private bool  KeyStatus = false;
	
	void  Start (){
	}
	
	void  Update (){
		GameObject PlayKey = GameObject.Find("Obj_Player");
		KeyStatus = PlayKey.GetComponent<GameCSharp_PlayerStatus>().Key(false);
		
		switch(KeyStatus)
		{
		case true:
			guiTexture.texture = Key1;
			break;
			
		case false:
			guiTexture.texture = Key2;
			break;
		}
	}
}
