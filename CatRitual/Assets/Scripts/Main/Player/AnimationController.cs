using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class AnimationController : MonoBehaviour {

	[HideInInspector] public MoveScript moveScript;
	[HideInInspector] public SpriteRenderer spriteRenderer;

	[SerializeField] public Sprite up	;
	[SerializeField] public Sprite left	;
	[SerializeField] public Sprite down	;

	void Awake () {
		moveScript = GetComponentInParent<MoveScript> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	void FixedUpdate () {
		Vector2 velocity = moveScript.lastMovement;

		if (velocity.magnitude < 0.01f)
			return;

		if (Mathf.Abs (velocity.x) > Mathf.Abs (velocity.y)) {
			spriteRenderer.sprite = left;
			Vector3 scale = transform.localScale;
			scale.x = velocity.x > 0 ? -1 : 1;
			transform.localScale = scale;
		} else {
			if (velocity.y > 0)
				spriteRenderer.sprite = up;
			else
				spriteRenderer.sprite = down;

			Vector3 scale = transform.localScale;
			scale.x = Mathf.Abs (scale.x);
			transform.localScale = scale;
		}
	}
}
