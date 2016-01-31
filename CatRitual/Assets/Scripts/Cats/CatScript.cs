using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game.Cat {

	[System.Serializable]
	public struct CatDay {
		public Sprite todaysSprite;
	}

	public class CatScript : MonoBehaviour {

		[SerializeField] public List <CatDay> catDays;

		[HideInInspector] public SpriteRenderer spriteRenderer;
		void Start () {
			GameManager.AddAction (OnDayChange);
		}
		void OnDayChange () {
			if (GameManager.day < catDays.Count) {
				spriteRenderer.sprite = catDays[GameManager.day].todaysSprite;
			}
		}
	}
}
