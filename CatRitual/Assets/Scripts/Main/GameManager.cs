using UnityEngine;
using UnityEngine.Events;

using System.Collections;

public class GameManager : MonoBehaviour {

	public static UnityEvent onDayUpdate;

	public static int day = 0;

	public static void AddAction (UnityAction action) {
		if (onDayUpdate == null)
			onDayUpdate = new UnityEvent ();
		onDayUpdate.AddListener (action);
	}
	public void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			NextDay ();
		}
	}
	public void NextDay () {
		day++;
		onDayUpdate.Invoke ();
	}
}
