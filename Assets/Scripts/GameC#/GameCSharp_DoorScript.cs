using UnityEngine;
using System.Collections;

public class GameCSharp_DoorScript : MonoBehaviour
{
	private float DoorDist = 4;
	private Vector3 TargDir;
	private float TargDist;
	private Transform PlayTarg;
	private Transform thisTransform;

	// Use this for initialization
	void Start ()
	{
		thisTransform = GetComponent<Transform> ();
		if (!PlayTarg)
		{
			PlayTarg = GameObject.Find ("Obj_Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (PlayTarg)
		{
			TargDir = PlayTarg.position - thisTransform.position;
			TargDist = TargDir.magnitude;
		}
		if (TargDist <= DoorDist)
		{
			GameObject PlayDamange = GameObject.Find ("Obj_Player");
			bool KeyStatus = PlayDamange.GetComponent<GameCSharp_PlayerStatus> ().Key (false);
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
}
