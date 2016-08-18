using UnityEngine;
using System.Collections;

public class CounterCSharp_Count : MonoBehaviour
{
	private float timers = 0.0f;
	private int counter1 = 0;
	private int counter2 = 0;
	private int counter3 = 0;
	private int counter4 = 0;
	private int counter5 = 0;
	private string[] sA = new string[100];
	private GameObject TimeTarg;
	private GameObject ScoreTarg1;
	private GameObject ScoreTarg2;
	private GameObject ScoreTarg3;
	private GameObject ScoreTarg4;
	private GameObject ScoreTarg5;
	// Use this for initialization
	void Start ()
	{
		if (!TimeTarg)
		{
			TimeTarg = GameObject.Find ("Con_GuiTimeHUB");
		}
		if (!ScoreTarg1)
		{
			ScoreTarg1 = GameObject.Find ("Con_GuiScoreHUB1");
		}
		if (!ScoreTarg2)
		{
			ScoreTarg2 = GameObject.Find ("Con_GuiScoreHUB2");
		}
		if (!ScoreTarg3)
		{
			ScoreTarg3 = GameObject.Find ("Con_GuiScoreHUB3");
		}
		if (!ScoreTarg4)
		{
			ScoreTarg4 = GameObject.Find ("Con_GuiScoreHUB4");
		}
		if (!ScoreTarg5)
		{
			ScoreTarg5 = GameObject.Find ("Con_GuiScoreHUB5");
		}
		timers = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//print(timers);
		if (timers < 10.0f)
		{
			timers += Time.deltaTime;
			Random.Range (0, 1000000);
			counter1++;

		}
		else if (timers < 20.0f)
		{
			timers += Time.deltaTime;
			int x;
			for (int i = 0; i < 15000000; i++)
			{
				x = i;
			}
			counter2++;
		}
		else if (timers < 30.0f)
		{
			timers += Time.deltaTime;
			string x;
			for (int i = 0; i < 15000000; i++)
			{
				x = "test";
			}
			counter3++;
		}
		else if (timers < 40.0f)
		{
			timers += Time.deltaTime;
			string x;
			for (int i = 0; i < 15000000; i++)
			{
				x = "";
				x += "test";
			}
			counter4++;
		}
		else if (timers < 50.0f)
		{
			timers += Time.deltaTime;
			string[] s = sA;
			for (int i = 0; i < 150000; i++)
			{
				for(int m = 0; m < s.Length; m++)
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
		TimeTarg.GetComponent<BenchmarkCSharp_Time> ().TimeClock (timers);
		ScoreTarg1.GetComponent<BenchmarkCSharp_Score> ().ScoreCounter (counter1);
		ScoreTarg2.GetComponent<BenchmarkCSharp_Score> ().ScoreCounter (counter2);
		ScoreTarg3.GetComponent<BenchmarkCSharp_Score> ().ScoreCounter (counter3);
		ScoreTarg4.GetComponent<BenchmarkCSharp_Score> ().ScoreCounter (counter4);
		ScoreTarg5.GetComponent<BenchmarkCSharp_Score> ().ScoreCounter (counter5);
	}
}
