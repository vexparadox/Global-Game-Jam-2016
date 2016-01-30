using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class MoveScript : MonoBehaviour {

	[SerializeField] public float speed = 1;
	[SerializeField] public int numberOfCasts = 5;

	[HideInInspector] new public Rigidbody2D rigidBody2D;

	void Awake () {
		rigidBody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical	 = Input.GetAxis ("Vertical"  );
	
		Vector2 delta = new Vector3 (horizontal, vertical);
		delta *= speed * Time.deltaTime;
	
		float moveTo;
		Vector3 targetPosition = transform.position + (Vector3)delta;

		rigidBody2D.MovePosition (targetPosition);
	}
}
