using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Game.Bubble;

namespace Game.Cat {

	[System.Serializable]
	public struct DailyThought {
		public Sprite todaysThought;
	}
	public class DailyThinker : MonoBehaviour {

		[SerializeField] public List <DailyThought> dailyThoughts;
		[SerializeField] public Vector3 offset;
		[SerializeField] public Vector3 eulerRotation;

		[HideInInspector] public SpriteRenderer spriteRenderer;
		[HideInInspector] public BubbleManager bubbleManager;

		void Start () {
			GameManager.AddAction (OnDayChange);
			bubbleManager = BubbleManager.NewBubble (transform.position + offset, dailyThoughts [GameManager.day].todaysThought);
			bubbleManager.transform.SetParent (transform);
			bubbleManager.transform.eulerAngles = eulerRotation;
		}
		void OnDayChange () {
			if (GameManager.day < dailyThoughts.Count) {
				bubbleManager.sprite = dailyThoughts[GameManager.day].todaysThought;
			}
		}
	}
}
