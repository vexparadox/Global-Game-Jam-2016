using UnityEngine;
using System.Collections;
[RequireComponent (typeof (MoveScript))]
public class PlayerControlScript : MonoBehaviour {

	MoveScript moveScript;

	void Awake () {
		moveScript = GetComponent<MoveScript> ();
	}

	void FixedUpdate () {
		moveScript.Move (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));
	}
}
