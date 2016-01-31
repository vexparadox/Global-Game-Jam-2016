using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class MoveScript : MonoBehaviour {

	[SerializeField] public float speed = 1;
	[SerializeField] public int numberOfCasts = 5;

	[SerializeField] public float distanceForFootstep = 1;
	[SerializeField] public bool footTrail;


	[HideInInspector] public Rigidbody2D rigidBody2D;
	[HideInInspector] public Vector2 lastMovement;

	[HideInInspector] public float totalWalk;

	void Awake () {
		rigidBody2D = GetComponent<Rigidbody2D> ();
	}

	public void Move (Vector2 delta) {
		delta.Normalize ();
		delta *= speed * Time.deltaTime;
	
		Vector3 targetPosition = transform.position + (Vector3)delta;
		lastMovement = delta;

		totalWalk += delta.magnitude;


		if (footTrail && totalWalk > distanceForFootstep) {
			GameObject foot = Instantiate (Resources.Load <GameObject> ("Prefabs/FootStep"), transform.position + Vector3.forward, Quaternion.identity) as GameObject;
			SFX.PlayFootStep ();
			Vector3 euler = foot.transform.eulerAngles;
			euler.z =-GameMath.Angle (delta);

			foot.transform.eulerAngles = euler;
			totalWalk = 0;
		}

		rigidBody2D.MovePosition (targetPosition);
	}
}
