#pragma strict
private var timer = 0.0f;
function Start () {

}

function Update ()
{
	var format : String  = System.String.Format("{0:F2} SEC",timer);
       	guiText.text = format;
}

function TimeClock(TimeMethod : float)
{
	timer = TimeMethod;
}