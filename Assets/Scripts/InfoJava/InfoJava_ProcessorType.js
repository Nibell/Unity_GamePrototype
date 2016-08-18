#pragma strict

function Start () {

}

function Update () {
	var format : String  = SystemInfo.processorType;
       	guiText.text = format;
}