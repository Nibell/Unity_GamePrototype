#pragma strict

function Start () {

}

function Update () {
	var format : String  = SystemInfo.operatingSystem;
       	guiText.text = format;
}