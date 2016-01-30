using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (MoveScript))]
public class AIScript : MonoBehaviour {

	public List <Vector2> vector;
	public int _index;

	[HideInInspector] public MoveScript moveScript;

	public int index {
		get {
			return _index;
		}
		set {
			if (value < 0) {
				index = vector.Count - value;
			} else if (value >= vector.Count) {
				index = value - vector.Count;
			} else {
				_index = value; 
			}
		}
	}

	void Awake () {
		moveScript = GetComponent<MoveScript> ();
	}

	void FixedUpdate () {
		Vector2 moveDirection = vector [index] - (Vector2)transform.position;
		if (moveDirection.magnitude < 0.5f)
			index++;
		moveScript.Move (moveDirection);
		//moveScript.Move (
	}
	void OnDrawGizmosSelected () {
		foreach (Vector2 vec in vector) {
			Gizmos.DrawWireSphere (vec, 0.2f);
		}
	}
}
