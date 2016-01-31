using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class MoveScript : MonoBehaviour {

	[SerializeField] public float speed = 1;
	[SerializeField] public int numberOfCasts = 5;

	[SerializeField] public float distanceForFootstep = 1;
	[SerializeField] public bool footTrail;

	[HideInInspector] public bool leftFoot;

	[HideInInspector] public const float footStepZPos = 10; 
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

			string footString = leftFoot ? "Prefabs/FootStepL" : "Prefabs/FootStepR";

			Vector3 pos = transform.position;
			if (Mathf.Abs (delta.y) > Mathf.Abs (delta.x)) {
				pos.x += leftFoot ? 0.3f : -0.3f;
			}

			leftFoot = !leftFoot;

			pos.z = footStepZPos;

			GameObject foot = Instantiate (Resources.Load <GameObject> (footString), pos, Quaternion.identity) as GameObject;
			SFX.PlayFootStep ();
			Vector3 euler = foot.transform.eulerAngles;
			euler.z =-GameMath.Angle (delta);

			foot.transform.eulerAngles = euler;
			totalWalk = 0;
		}

		rigidBody2D.MovePosition (targetPosition);
	}
}
