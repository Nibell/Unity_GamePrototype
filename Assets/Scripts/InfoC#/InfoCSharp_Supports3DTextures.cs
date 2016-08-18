using UnityEngine;
using System.Collections;

public class InfoCSharp_Supports3DTextures : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		string format = System.String.Format("{0}",SystemInfo.supports3DTextures);
		guiText.text = format;
	}
}
