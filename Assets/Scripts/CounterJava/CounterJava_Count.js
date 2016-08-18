#pragma strict
private var timers = 0.0;
private var counter1 = 0;
private var counter2 = 0;
private var counter3 = 0;
private var counter4 = 0;
private var counter5 = 0;
public var sA : String[] = new String[100];
private var TimeTarg : GameObject;
private var ScoreTarg1 : GameObject;
private var ScoreTarg2 : GameObject;
private var ScoreTarg3 : GameObject;
private var ScoreTarg4 : GameObject;
private var ScoreTarg5 : GameObject;
	
function Start ()
{ 
	if(!TimeTarg)
	{
		TimeTarg = GameObject.Find("Con_GuiTimeHUB");
	}
	if(!ScoreTarg1)
	{
		ScoreTarg1 = GameObject.Find("Con_GuiScoreHUB1");
	}
	if(!ScoreTarg2)
	{
		ScoreTarg2 = GameObject.Find("Con_GuiScoreHUB2");
	}
	if(!ScoreTarg3)
	{
		ScoreTarg3 = GameObject.Find("Con_GuiScoreHUB3");
	}
	if(!ScoreTarg4)
	{
		ScoreTarg4 = GameObject.Find("Con_GuiScoreHUB4");
	}
	if(!ScoreTarg5)
	{
		ScoreTarg5 = GameObject.Find("Con_GuiScoreHUB5");
	}
	timers = Time.deltaTime;
}

function Update () 
{
	//print(timers);
	if (timers < 10.0f)
	{
		timers += Time.deltaTime;
		Random.Range(0, 1000000);
		counter1++;
	}
	else if (timers < 20.0f)
	{
		timers += Time.deltaTime;
		var x : int;
		for (var i : int = 0; i < 15000000; i++)
		{
			x = i;
		}
		counter2++;
	}
	else if (timers < 30.0f)
	{
		timers += Time.deltaTime;
		var y : String;
		for (var j : int = 0; j < 15000000; j++)
		{
			y = "test";
		}
		counter3++;
	}
	else if (timers < 40.0f)
	{
		timers += Time.deltaTime;
		var z : String;
		for (var k : int = 0; k < 15000000; k++)
		{
			z = "";
			z += "test";
		}
		counter4++;
	}
	else if (timers < 50.0f)
	{
		timers += Time.deltaTime;
		var s : String[] = sA;
		for (var l : int = 0; l < 150000; l++)
		{
			for(var m : int = 0; m < s.length; m++)
			{
            			s[m] = "test";
        		}
		}
		counter5++;
	}
	else
	{
		//print("done");
		//print(counter);
	}
	
	TimeTarg.GetComponent(BenchmarkJava_Time).TimeClock(timers);
	ScoreTarg1.GetComponent(BenchmarkJava_Score).ScoreCounter(counter1);
	ScoreTarg2.GetComponent(BenchmarkJava_Score).ScoreCounter(counter2);
	ScoreTarg3.GetComponent(BenchmarkJava_Score).ScoreCounter(counter3);
	ScoreTarg4.GetComponent(BenchmarkJava_Score).ScoreCounter(counter4);
	ScoreTarg5.GetComponent(BenchmarkJava_Score).ScoreCounter(counter5);
}