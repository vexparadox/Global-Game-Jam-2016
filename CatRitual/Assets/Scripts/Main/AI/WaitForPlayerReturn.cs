using UnityEngine;
using UnityEngine.Events;

using System.Collections;
[RequireComponent (typeof (BoxCollider2D))]
public class WaitForPlayerReturn : MonoBehaviour {

	[HideInInspector] public bool playerLeft;
	[SerializeField] public Rigidbody2D evilCat;
	[SerializeField] public UnityEvent unityEvent;

	void OnTriggerExit2D (Collider2D coll) {
		if (coll.CompareTag ("Player"))
			playerLeft = true;
	}
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.CompareTag ("Player") && playerLeft) {
			evilCat.isKinematic = false;
			unityEvent.Invoke ();
		}
	}
	void Update () {
	
	}
}
