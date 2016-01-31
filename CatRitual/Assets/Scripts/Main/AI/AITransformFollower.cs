using UnityEngine;
using UnityEngine.Events;

using System.Collections;

public class AITransformFollower : MonoBehaviour {

	[SerializeField] public Transform followTransform;
	[SerializeField] public UnityEvent onTargetMissing;
	[SerializeField] public Transform player;

	[HideInInspector] public MoveScript moveScript;

	void Awake () {
		moveScript = GetComponent<MoveScript> ();
	}
	void FixedUpdate () {
		if (followTransform == null) {
			moveScript.Move (Vector2.zero);
			followTransform = player;
			onTargetMissing.Invoke ();
		} else {
			moveScript.Move ((followTransform.transform.position - transform.position).normalized);
		}
	}
}
