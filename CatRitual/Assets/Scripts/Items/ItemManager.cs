using UnityEngine;
using System.Collections;

namespace Game.Items {
	public class ItemManager : MonoBehaviour {
		public static ItemSlot [] itemSlots;
		
		void Awake () {
			if (itemSlots == null)
				itemSlots = new ItemSlot[(int)Item.Length];
		}
		public static void ItemPickedup (Item item) {
			if (itemSlots == null)
				new GameObject ("ItemManager").AddComponent <ItemManager> ();
			itemSlots [(int)item].amount++;
		}
		public static ItemSlot [] ItemSlots () {
			if (itemSlots == null)
				new GameObject ("ItemManager").AddComponent <ItemManager> ();
			return itemSlots;
		}
	}
}