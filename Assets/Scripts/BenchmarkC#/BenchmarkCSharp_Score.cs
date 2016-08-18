using UnityEngine;
using System.Collections;

public class BenchmarkCSharp_Score : MonoBehaviour
{
	private int score = 0;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		string format = System.String.Format("{0:F0} Score",score);
		guiText.text = format;
	}
	public void ScoreCounter(int ScoreMethod)
	{
		score = ScoreMethod;
	}
}
