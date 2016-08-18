//////////////////////////////////////////////////////////////
// GameJava_KeyScript.js
//
// GameJava_KeyScript creates a 2D animation for the GuiTexture
//////////////////////////////////////////////////////////////

#pragma strict

var Key1 : Texture2D;
var Key2 : Texture2D;

private var KeyStatus : boolean = false;

function Start()
{
}

function Update()
{
	var PlayKey = GameObject.Find("Obj_Player");
	KeyStatus = PlayKey.GetComponent(GameJava_PlayerStatus).Key(false);
	
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