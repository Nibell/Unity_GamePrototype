#pragma strict

function Start () {

}

function Update () {
	var format : String  = System.String.Format("{0}",SystemInfo.supports3DTextures);
       	guiText.text = format;
}