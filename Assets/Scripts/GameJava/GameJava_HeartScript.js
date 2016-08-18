//////////////////////////////////////////////////////////////
// GameJava_HeartScript.js
//
// GameJava_HeartScript creates a 2D animation for the GuiTexture
//////////////////////////////////////////////////////////////

#pragma strict
var Health1 : Texture2D;
var Health2 : Texture2D;
var Health3 : Texture2D;
var Health4 : Texture2D;
var Health5 : Texture2D;
var Health6 : Texture2D;
var Health7 : Texture2D;
var Health8 : Texture2D;
var Health9 : Texture2D;
var Health10 : Texture2D;
var Health11 : Texture2D;
var Health12 : Texture2D;
var Health13 : Texture2D;

var HealthStatus : int;

function Start()
{
}

function Update() 
{
	var PlayHealth = GameObject.Find("Obj_Player");
	HealthStatus = PlayHealth.GetComponent(GameJava_PlayerStatus).Health();
	
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