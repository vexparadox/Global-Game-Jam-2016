using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Game.Items {
	[System.Serializable]
	public struct ItemCheck {
		[SerializeField] public Item wantedItem;
		[SerializeField] public int amount;
		[SerializeField] public UnityEvent onDelivery; 
		public bool GotTheStuff () {
			return ItemManager.itemSlots [(int)wantedItem].amount >= amount;
		}
	}
	public class ItemChecker : MonoBehaviour {

		[SerializeField] public List<ItemCheck> itemChecksPerDay;

		public static ItemChecker instance;

		void Awake () {
			if (instance != null)
				Destroy (gameObject);
			instance = this;
		}
		void OnTriggerEnter2D (Collider2D coll) {
			if (coll.CompareTag ("Player") && GotTheStuff ()) {
				itemChecksPerDay[GameManager.day].onDelivery.Invoke ();
			}
		}
		bool GotTheStuff () {
			if (itemChecksPerDay.Count > GameManager.day) {
				ItemCheck currentItem = itemChecksPerDay [GameManager.day];
				return currentItem.amount <= ItemManager.ItemSlots ()[GameManager.day].amount;
			}
			return false;
		}
	}
}
