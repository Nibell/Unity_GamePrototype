#pragma strict
private var score = 0;
function Start () {

}

function Update ()
{
	var format : String  = System.String.Format("{0:F0} Score",score);
       	guiText.text = format;
}

function ScoreCounter(ScoreMethod : int)
{
	score = ScoreMethod;
}