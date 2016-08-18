#pragma strict

function Start () {

}

function Update () {
	var format : String  = SystemInfo.graphicsDeviceVendor;
       	guiText.text = format;
}