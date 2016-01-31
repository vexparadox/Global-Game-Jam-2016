using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public static UnityEvent onEnterNewScreen;
	public static bool isOnMainMap = true;
	public static void addOnEnterNewScreen (UnityAction action) {
		if (onEnterNewScreen == null) {
			onEnterNewScreen = new UnityEvent ();
		}
		onEnterNewScreen.AddListener (action);
	}

	[SerializeField] public Transform player;
	[SerializeField] public Vector2 grid = new Vector2 (10,10);

	void Start () {
		GameManager.AddAction (OnDayChange);
		onEnterNewScreen.Invoke ();
	}
	void OnDayChange () {
		if (onEnterNewScreen != null)
			onEnterNewScreen.Invoke ();
	}
	void Update () {
		if (!isOnMainMap ||!player) {
			return;
		}
		float width = Camera.main.orthographicSize / 3f * 4f;
		Vector2 delta = player.transform.position - transform.position;

		Vector3 newPos = transform.position;

		bool changed = false;
		if ((width - Mathf.Abs (delta.x)) < 0) {
			newPos.x += width * (delta.x < 0 ? -1 : 1) * 2;
			changed = true;
		}
		if ((Camera.main.orthographicSize - Mathf.Abs (delta.y)) < 0) {
			newPos.y += Camera.main.orthographicSize * 2 * (delta.y < 0 ? -1 : 1);
			changed = true;
		}
		if (changed) {
			transform.position = newPos;
			if (onEnterNewScreen != null)
				onEnterNewScreen.Invoke ();
		}
	}
	void OnDrawGizmos () {

		float screenWidth = Camera.main.orthographicSize / 3f * 4f * 2;
		float screenHeight = Camera.main.orthographicSize * 2;


		for (float x = -grid.x * screenWidth - screenWidth * 0.5f; x < grid.x * screenWidth; x += screenWidth)
			Gizmos.DrawLine (new Vector3 (x, -99999), new Vector3 (x, 999999));	
		for (float y = -grid.y * screenHeight - screenHeight * 0.5f; y < grid.y * screenHeight; y += screenHeight) {
			Gizmos.DrawLine (new Vector3 (-99999, y), new Vector3 (999999, y));
		}
	}
}
