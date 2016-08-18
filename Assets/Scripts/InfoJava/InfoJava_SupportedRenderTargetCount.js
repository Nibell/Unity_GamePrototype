#pragma strict

function Start () {

}

function Update () {
	var format : String  = System.String.Format("{0}",SystemInfo.supportedRenderTargetCount);
       	guiText.text = format;
}