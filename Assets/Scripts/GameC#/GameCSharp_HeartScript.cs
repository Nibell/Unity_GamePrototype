//////////////////////////////////////////////////////////////
// GameCSharp_HeartScript.cs
//
// GameCSharp_HeartScript creates a 2D animation for the GuiTexture
//////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GameCSharp_HeartScript : MonoBehaviour
{
	public Texture2D Health1 = null;
	public Texture2D Health2 = null;
	public Texture2D Health3 = null;
	public Texture2D Health4 = null;
	public Texture2D Health5 = null;
	public Texture2D Health6 = null;
	public Texture2D Health7 = null;
	public Texture2D Health8 = null;
	public Texture2D Health9 = null;
	public Texture2D Health10 = null;
	public Texture2D Health11 = null;
	public Texture2D Health12 = null;
	public Texture2D Health13 = null;
	int HealthStatus = 0;
	
	void Start()
	{
	}
	
	void Update()
	{
		GameObject PlayHealth= GameObject.Find("Obj_Player");
		HealthStatus = PlayHealth.GetComponent<GameCSharp_PlayerStatus>().Health();

		switch(HealthStatus)
		{
		case 1:
			guiTexture.texture = Health1;
			break;
			
		case 2:
			guiTexture.texture = Health2;
			break;
			
		case 3:
			guiTexture.texture = Health3;
			break;
			
		case 4:
			guiTexture.texture = Health4;
			break;
			
		case 5:
			guiTexture.texture = Health5;
			break;
			
		case 6:
			guiTexture.texture = Health6;
			break;
			
		case 7:
			guiTexture.texture = Health7;
			break;
			
		case 8:
			guiTexture.texture = Health8;
			break;
			
		case 9:
			guiTexture.texture = Health9;
			break;
			
		case 10:
			guiTexture.texture = Health10;
			break;
			
		case 11:
			guiTexture.texture = Health11;
			break;
			
		case 12:
			guiTexture.texture = Health12;
			break;
			
		case 13:
			guiTexture.texture = Health13;
			break;
		}
	}
}