using UnityEngine;
using System.Collections;
namespace Game.Bubble {
	public class BubbleManager : MonoBehaviour {
		
		public const float zPos = -10f;

		[SerializeField] public float timeBetweenBubbles = 0.4f;
		[HideInInspector] public int indexOfCurrentBubble = 0;
		[HideInInspector] public float timeOfLastBubbleCreation;
		[HideInInspector] public SpriteRenderer spriteRenderer;

		public Sprite sprite {
			get {
				return spriteRenderer.sprite;
			}
			set {
				spriteRenderer.sprite = value;
			}
		}

		public static BubbleManager NewBubble (Vector2 position, Sprite intialThought) {
			BubbleManager manager = ((GameObject)(Instantiate (
									Resources.Load<GameObject> ("Prefabs/BubbleDisplayer"),
			              			new Vector3 (position.x, position.y, zPos),
									Quaternion.identity))).GetComponent<BubbleManager> ();
			manager.spriteRenderer.sprite = intialThought;
			return manager;
		}
		void Awake () {
			CameraScript.addOnEnterNewScreen (OnEnterNewScreen);
			spriteRenderer = transform.GetChild (transform.childCount - 1).gameObject.GetComponent<SpriteRenderer> ();
		}
		void OnEnterNewScreen () {
			foreach (Transform child in transform) {
				child.gameObject.SetActive (false); 
			}
			indexOfCurrentBubble = 0;
			timeOfLastBubbleCreation = Time.time;
		}
		void Update () {
			if (Time.time > timeOfLastBubbleCreation + timeBetweenBubbles) {
				if (indexOfCurrentBubble < transform.childCount)
					transform.GetChild (indexOfCurrentBubble++).gameObject.SetActive (true);
				timeOfLastBubbleCreation = Time.time;
			}
		}
	}
}