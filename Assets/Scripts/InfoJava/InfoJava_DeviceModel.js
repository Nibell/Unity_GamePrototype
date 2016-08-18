#pragma strict

function Start () {

}

function Update () {
	var format : String  = SystemInfo.deviceModel;
       	guiText.text = format;
}