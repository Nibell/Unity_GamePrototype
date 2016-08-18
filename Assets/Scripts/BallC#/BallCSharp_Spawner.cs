using UnityEngine;
using System.Collections;

public class BallCSharp_Spawner : MonoBehaviour
{
	public GameObject CSharpBallSpawn;
	private Vector3 spawn_position;
	private float timer = 0.0f;
	private float timers = 0.0f;
	private int counter = 0;
	private int limit = 0;
	private Transform BallTarg;
	private GameObject TimeTarg;
	private GameObject ScoreTarg;

	void Start ()
	{
		if (!BallTarg)
		{
			BallTarg = GameObject.Find ("Obj_Balls").transform;
		}
		if (!TimeTarg)
		{
			TimeTarg = GameObject.Find ("Con_GuiTimeHUB");
		}
		if (!ScoreTarg)
		{
			ScoreTarg = GameObject.Find ("Con_GuiScoreHUB");
		}
		timers = Time.deltaTime;
	}

	void Update ()
	{
		//print(timers);
		if (timers < 60.0f)
		{
			timers += Time.deltaTime;
			counter++;
			TimeTarg.GetComponent<BenchmarkCSharp_Time> ().TimeClock (timers);
			ScoreTarg.GetComponent<BenchmarkCSharp_Score> ().ScoreCounter (counter);
			timer += Time.deltaTime;
			if (timer > 0.50f)
			{
				if (limit < 20)
				{
					BallSpawn ();
					timer = 0.0f;
					limit++;
				}
			}
		}
		else
		{
			for (int i=BallTarg.childCount-1; i>=0; --i)
			{
				var child = BallTarg.GetChild (i).gameObject;
				Destroy (child);
			}
			//print("done");
			//print(counter);
		}
	}

	void BallSpawn ()
	{
		spawn_position = new Vector3 (Random.Range (-9, 10), 20, Random.Range (0, 20));
		GameObject temp_spawn_ball = (GameObject)Instantiate (CSharpBallSpawn, spawn_position, Quaternion.identity);
		temp_spawn_ball.transform.parent = BallTarg;
	}
}
