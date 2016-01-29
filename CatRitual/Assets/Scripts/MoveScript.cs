using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	[SerializeField] public float speed;
	[SerializeField] public int numberOfCasts;

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
