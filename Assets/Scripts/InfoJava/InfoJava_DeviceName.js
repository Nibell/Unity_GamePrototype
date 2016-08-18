#pragma strict

function Start () {

}

function Update () {
	var format : String  = SystemInfo.deviceName;
       	guiText.text = format;
}