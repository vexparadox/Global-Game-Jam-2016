using UnityEngine;
using System.Collections;

public class ZoneChange : MonoBehaviour {
	public GameObject changeLocation;
	public Camera cameraToChange;
	void OnTriggerEnter2D(Collider2D other) {
		if (!other.CompareTag ("Player")) {
			return;
		}
		Bounds renderBounds = GetComponent<Renderer> ().bounds;
		Vector2 centerBotPosition = new Vector2 (renderBounds.center.x, renderBounds.center.y - renderBounds.extents.y);

		Vector2 deltaPoint = (Vector2)cameraToChange.transform.position - centerBotPosition;

		Vector3 pos = changeLocation.transform.position + (Vector3)deltaPoint;
		pos.z = cameraToChange.transform.position.z;

		cameraToChange.transform.position = pos;

		deltaPoint = (Vector2)other.transform.position - centerBotPosition;
		pos = changeLocation.transform.position + (Vector3)deltaPoint;

		pos.z = other.transform.position.z;

		other.transform.position = pos;
	}
}