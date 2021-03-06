﻿//////////////////////////////////////////////////////////////
// CubeJava_Spawner.js
//
// CubeJava_Spawner creates a cube spawner that drops cubes
//////////////////////////////////////////////////////////////

#pragma strict

public var JavaBallSpawn : GameObject;
private var spawn_position;
private var timer = 0.0;
private var limit = 0;
private var timers = 0.0;
private var counter = 0;
private var BallTarg : Transform;
private var TimeTarg : GameObject;
private var ScoreTarg : GameObject;;

function Start()
{
	if(!BallTarg)
	{
		BallTarg = GameObject.Find("Obj_Balls").transform;
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

function Update()
{
	//print(timers);
	if (timers < 60.0f)
	{
		timers += Time.deltaTime;
		counter++;
		TimeTarg.GetComponent(BenchmarkJava_Time).TimeClock(timers);
		ScoreTarg.GetComponent(BenchmarkJava_Score).ScoreCounter(counter);
		timer += Time.deltaTime;
		if (timer > 0.50f)
		{
			if (limit < 20)
			{
				BallSpawn ();
				timer = 0.0;
				limit++;
			}
		}
	}
	else
	{
		for (var i=BallTarg.childCount-1; i>=0; --i)
		{
			var child = BallTarg.GetChild (i).gameObject;
			Destroy (child);
		}
		//print("done");
		//print(counter);
	}
}

function BallSpawn()
{
	spawn_position = Vector3(Random.Range(-9,10),20,Random.Range(0,20));
	var temp_spawn_ball = Instantiate(JavaBallSpawn,spawn_position, Quaternion.identity);
	temp_spawn_ball.transform.parent = BallTarg;
}