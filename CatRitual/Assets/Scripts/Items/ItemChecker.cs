using UnityEngine;
using UnityEngine.Events;
using System.Collections;
namespace Game.Items {
	public class ItemChecker : MonoBehaviour {
	
		[SerializeField] public Item wantedItem;
		[SerializeField] public int amount;
		[SerializeField] public UnityEvent onDelivery; 
		void OnTriggerEnter2D (Collider2D coll) {
			if (coll.CompareTag ("Player") && ItemManager.ItemSlots ()[(int)wantedItem].amount >= amount) {
				onDelivery.Invoke ();
				Destroy (gameObject);
			}
		}
	}
}
