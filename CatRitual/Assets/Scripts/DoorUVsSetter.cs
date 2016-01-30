using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DoorUVsSetter : MonoBehaviour {
	public MeshFilter quad;
	public ZoneChange teleportScript;
	// Use this for initialization
	void Start () {
		if (Application.isPlaying) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
