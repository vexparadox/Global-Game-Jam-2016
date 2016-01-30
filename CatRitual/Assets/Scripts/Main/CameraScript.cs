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

	void Start () {
		GameManager.AddAction (OnDayChange);
	}
	void OnDayChange () {
		if (onEnterNewScreen != null)
			onEnterNewScreen.Invoke ();
	}
	void Update () {
		if (!isOnMainMap) {
			return;
		}
		if (!player) 
			return;
		float width = Camera.main.orthographicSize / (float)Screen.height * Screen.width;
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


}
