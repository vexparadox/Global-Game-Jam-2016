using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	[SerializeField] public Transform player;

	void Update () {
		if (!player) 
			return;
		float width = Camera.main.orthographicSize / (float)Screen.height * Screen.width;
		Vector2 delta = player.transform.position - transform.position;

		Vector3 newPos = transform.position;
		bool changed = true;

		if ((width - Mathf.Abs (delta.x)) < 0)
			newPos.x += width * (delta.x < 0 ? -1 : 1) * 2;
		if ((Camera.main.orthographicSize - Mathf.Abs (delta.y)) < 0)
			newPos.y += Camera.main.orthographicSize * 2 * (delta.y < 0 ? -1 : 1);

		transform.position = newPos;
	}
}
