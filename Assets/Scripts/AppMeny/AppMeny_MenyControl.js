//////////////////////////////////////////////////////////////
// AppMeny_MenyControl.js
//
// AppMeny_MenyControl creates a 2D control scheme where the left
// pad is used to move the character, and the right pad is used
// to make the character jump.
//////////////////////////////////////////////////////////////

#pragma strict

@script RequireComponent(CharacterController)

// This script must be attached to a GameObject that has a CharacterController
var Button1 : Texture2D;
var Button2 : Texture2D;
var Button3 : Texture2D;
var Button4 : Texture2D;
var Button5 : Texture2D;
var Button6 : Texture2D;
var Button7 : Texture2D;
var Button8 : Texture2D;
var Button9 : Texture2D;
var Button10 : Texture2D;
var Button11 : Texture2D;
var Button12 : Texture2D;

var Button1TouchPad : AppMeny_Joystick;
var Button2TouchPad : AppMeny_Joystick;
var Button3TouchPad : AppMeny_Joystick;
var Button4TouchPad : AppMeny_Joystick;
var MenyOption = 0;
var Button3Check = false;
var Button4Check = false;

function Start()
{
}

function OnEndGame()
{
	// Disable joystick when the game ends  
	Button1TouchPad.Disable();
	Button2TouchPad.Disable();
	Button3TouchPad.Disable();
	Button4TouchPad.Disable();
	
	// Don't allow any more control changes when the game ends
	this.enabled = false;
}

function Update()
{
	if(MenyOption == 1)
	{
		GameObject.Find("Con_Button1TouchPad").guiTexture.texture = Button5;
		GameObject.Find("Con_Button2TouchPad").guiTexture.texture = Button7;
		GameObject.Find("Con_Button3TouchPad").guiTexture.texture = Button9;
		GameObject.Find("Con_Button4TouchPad").guiTexture.texture = Button11;
	}
	else if(MenyOption == 2)
	{
		GameObject.Find("Con_Button1TouchPad").guiTexture.texture = Button6;
		GameObject.Find("Con_Button2TouchPad").guiTexture.texture = Button8;
		GameObject.Find("Con_Button3TouchPad").guiTexture.texture = Button10;
		GameObject.Find("Con_Button4TouchPad").guiTexture.texture = Button12;
	}	
	else
	{
		GameObject.Find("Con_Button1TouchPad").guiTexture.texture = Button1;
		GameObject.Find("Con_Button2TouchPad").guiTexture.texture = Button2;
		GameObject.Find("Con_Button3TouchPad").guiTexture.texture = Button3;
		GameObject.Find("Con_Button4TouchPad").guiTexture.texture = Button4;
	}
	
	if(Input.GetKeyDown(KeyCode.Escape))
 	{
 		if(MenyOption == 0)
        	{
        		Application.Quit();	
        	}
        	else
        	{
        		MenyOption = 0;
        	}
 	}
 	else if(Button1TouchPad.IsFingerDown())
 	{
 		if(MenyOption == 1)
        	{
        		Application.LoadLevel("CubeJava");
        	}
        	else if(MenyOption == 2)
        	{
        		Application.LoadLevel("CubeC#");
        	}	
        	else
        	{
        		Application.LoadLevel("GameJava");
 		}
 	}
 	else if(Button2TouchPad.IsFingerDown())
 	{
 		if(MenyOption == 1)
        	{
        		Application.LoadLevel("BallJava");
        	}
        	else if(MenyOption == 2)
        	{
        		Application.LoadLevel("BallC#");
        	}	
        	else
        	{
        		Application.LoadLevel("GameC#");
 		}	
 	}
 	else if(Button3TouchPad.IsFingerDown())
 	{
		if(MenyOption == 1)
		{
			Application.LoadLevel("CodeJava");

		}
		else if(MenyOption == 2)
		{
			Application.LoadLevel("CodeC#");
		}	
        	else
        	{
        		Button3Check = true;
 		}
	}
	else if(Button4TouchPad.IsFingerDown())
	{
		if(MenyOption == 1)
		{
			Application.LoadLevel("InfoJava");
		}
		else if(MenyOption == 2)
		{
			Application.LoadLevel("InfoC#");
		}
		else
		{
			Button4Check = true;
		}
	}
	else if((Button3TouchPad.IsFingerDown() == false) && (Button3Check == true))
	{
		MenyOption = 1;
		Button3Check = false;
	}
	else if((Button4TouchPad.IsFingerDown() == false) && (Button4Check == true))
	{
		MenyOption = 2;
		Button4Check = false;
	}
}