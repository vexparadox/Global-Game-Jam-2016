using UnityEngine;
using System.Collections;
[RequireComponent (typeof (BoxCollider2D))]
public class WaitForPlayerReturn : MonoBehaviour {

	[HideInInspector] public bool playerLeft;

	void OnTriggerExit2D (Collider2D coll) {
		if (coll.CompareTag ("Player"))
			playerLeft = true;
	}
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.CompareTag ("Player") && playerLeft) {

		}
	}
	void Update () {
	
	}
}
