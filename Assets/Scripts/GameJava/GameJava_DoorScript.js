#pragma strict
private var DoorDist : float = 4;
private var TargDir : Vector3;
private var TargDist : float;
private var PlayTarg : Transform;
private var thisTransform : Transform;

function Start ()
{
	thisTransform = GetComponent(Transform);
	if (!PlayTarg)
	{
		PlayTarg = GameObject.Find("Obj_Player").transform;
	}
}

function Update ()
{
	if (PlayTarg)
	{
		TargDir = PlayTarg.position - thisTransform.position;
		TargDist = TargDir.magnitude;
	}
	if (TargDist <= DoorDist)
	{
		var PlayDamange = GameObject.Find("Obj_Player");
		var KeyStatus = PlayDamange.GetComponent(GameJava_PlayerStatus).Key(false);
		if (KeyStatus)
		{
			Destroy (this.gameObject);
		}
		else
		{
		}
	}
	else
	{
	}
}