using UnityEngine;
using System.Collections;

public class InfoCSharp_OperatingSystem : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		string format = SystemInfo.operatingSystem;
		guiText.text = format;
	}
}
