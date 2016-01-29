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
	}
}