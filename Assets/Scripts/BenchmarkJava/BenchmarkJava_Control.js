//////////////////////////////////////////////////////////////
// CubeJava_Control.js
//
// CubeJava_Control creates a 2D control scheme where the back
// button is used to exit the application.
//////////////////////////////////////////////////////////////

#pragma strict

function Start ()
{

}

function Update ()
{
	if (Input.GetKeyDown(KeyCode.Escape))
	{
		Application.LoadLevel("AppMeny");
	}
}