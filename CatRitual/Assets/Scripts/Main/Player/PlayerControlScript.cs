using UnityEngine;
using System.Collections;
[RequireComponent (typeof (MoveScript))]
public class PlayerControlScript : MonoBehaviour {

	MoveScript moveScript;

	void Awake () {
		moveScript = GetComponent<MoveScript> ();
	}

	void FixedUpdate () {
		Debug.Log (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));
		moveScript.Move (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));
	}
}
