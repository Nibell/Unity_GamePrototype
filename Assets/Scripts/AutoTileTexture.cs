using UnityEngine;
using System.Collections;

public class AutoTileTexture : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDrawGizmos()
	{
		//this.gameObject.renderer.material.SetTextureScale("_MainTex",new Vector2(this.gameObject.transform.lossyScale.x,this.gameObject.transform.lossyScale.y));
		this.gameObject.renderer.sharedMaterial.SetTextureScale("_MainTex",new Vector2(this.gameObject.transform.lossyScale.x,this.gameObject.transform.lossyScale.y));
	}
}
