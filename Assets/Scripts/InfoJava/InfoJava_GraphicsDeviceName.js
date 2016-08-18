#pragma strict

function Start () {

}

function Update () {
	var format : String  = SystemInfo.graphicsDeviceName;
       	guiText.text = format;
}