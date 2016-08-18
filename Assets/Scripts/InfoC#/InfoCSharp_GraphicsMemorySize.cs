using UnityEngine;
using System.Collections;

public class InfoCSharp_GraphicsMemorySize: MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		string format = System.String.Format("{0}",SystemInfo.graphicsMemorySize);
		guiText.text = format;
	}
}
