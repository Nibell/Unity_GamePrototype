using UnityEngine;
using System.Collections;

public class CubeCSharp_Spawner : MonoBehaviour
{
	public GameObject CSharpCubeSpawn;
	private Vector3 spawn_position;
	private float timer = 0.0f;
	private float timers = 0.0f;
	private int counter = 0;
	private Transform CubeTarg;
	private GameObject TimeTarg;
	private GameObject ScoreTarg;
    
	void  Start ()
	{
		if (!CubeTarg)
		{
			CubeTarg = GameObject.Find ("Obj_Cubes").transform;
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
			if (timer > 0.5f)
			{
				CubeSpawn ();
				timer = 0.0f;
			}
		}
		else
		{

			for (int i=CubeTarg.childCount-1; i>=0; --i)
			{
				var child = CubeTarg.GetChild (i).gameObject;
				Destroy (child);
			}
			//print("done");
			//print(counter);
		}
	}

	void CubeSpawn ()
	{
		spawn_position = new Vector3 (Random.Range (-9, 10), 20, Random.Range (0, 20));
		GameObject temp_spawn_cube = (GameObject)Instantiate (CSharpCubeSpawn, spawn_position, Quaternion.identity);
		temp_spawn_cube.transform.parent = CubeTarg;
	}
}