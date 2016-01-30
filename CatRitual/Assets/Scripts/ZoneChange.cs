using UnityEngine;
using System.Collections;

public class ZoneChange : MonoBehaviour {
	public GameObject changeLocation;
	public Camera cameraToChange;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Player") {
			return;
		}
		cameraToChange.transform.position = changeLocation.gameObject.transform.position;
		Vector3 v = new Vector3 (cameraToChange.transform.position.x, cameraToChange.transform.position.y, cameraToChange.transform.position.z - 12.3f);
		cameraToChange.transform.position = v;
		other.gameObject.transform.position = changeLocation.gameObject.transform.position;
		CameraScript.isOnMainMap = !CameraScript.isOnMainMap;
	}
}