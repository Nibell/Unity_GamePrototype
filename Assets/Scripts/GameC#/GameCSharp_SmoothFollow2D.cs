//////////////////////////////////////////////////////////////
//GameCSharp_SmoothFollow2D.cs
// 
// GameCSharp_SmoothFollow2D smoothes all in the camera screen
//////////////////////////////////////////////////////////////
/// 
using UnityEngine;
using System.Collections;

public class GameCSharp_SmoothFollow2D : MonoBehaviour
{
	public Transform target;
	private float smoothTime= 0.3f;
	private Transform thisTransform;
	private Vector2 velocity;
	
	private float positionX;
	private float positionY;
	private float positionZ;

	void Start ()
	{
		thisTransform = transform;
	}
	
	void Update ()
	{
		positionX = Mathf.SmoothDamp( thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
		positionY = Mathf.SmoothDamp( thisTransform.position.y, target.position.y, ref velocity.y, smoothTime);
		
		positionZ = thisTransform.position.z;
		thisTransform.position = new Vector3 (positionX, positionY, positionZ);

		//newVal.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, velocity.x, smoothTime);
		//newVal.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, velocity.y, smoothTime);
		//thisTransform.position.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, velocity.x, smoothTime);
		//thisTransform.position.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, velocity.y, smoothTime);
	}
}