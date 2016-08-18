using UnityEngine;
using System.Collections;

public class InfoCSharp_DeviceModel: MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		string format = SystemInfo.deviceModel;
		guiText.text = format;
	}
}
