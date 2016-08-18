using UnityEngine;
using System.Collections;

public class BenchmarkCSharp_Time : MonoBehaviour
{
	private float timer = 0.0f;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		string format = System.String.Format("{0:F2} SEC",timer);
		guiText.text = format;
	}
	public void TimeClock(float TimeMethod)
	{
		timer = TimeMethod;
	}
}
