﻿using UnityEngine;
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

		[HideInInspector] new public SpriteRenderer spriteRenderer;
		[HideInInspector] public BubbleManager bubbleManager;

		void Start () {
			GameManager.AddAction (OnDayChange);
			bubbleManager = BubbleManager.NewBubble (transform.position, dailyThoughts [GameManager.day].todaysThought);
			bubbleManager.transform.SetParent (transform);
		}
		void OnDayChange () {
			if (GameManager.day < dailyThoughts.Count) {
				spriteRenderer.sprite = dailyThoughts[GameManager.day].todaysThought;
			}
		}
	}
}
