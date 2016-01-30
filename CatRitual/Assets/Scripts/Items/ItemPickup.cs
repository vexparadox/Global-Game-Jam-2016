using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Game.Items {
	public struct ItemSlot {
		public Item item;
		public int amount;
		public ItemSlot (Item item) {
			this.item = item;
			amount = 0;
		}
	}
	public enum Item {
		Bomb, Length
	};
	public class ItemPickup : MonoBehaviour {
		[SerializeField]  public Item itemType;
		[HideInInspector] public UnityAction itemPickedup;
	
		void Awake () {
			
		}
	
		void OnTriggerEnter2D (Collider2D coll) {
			coll.CompareTag ("Player");
			ItemManager.ItemPickedup (itemType);
			Destroy (gameObject);
		}
	}
}
