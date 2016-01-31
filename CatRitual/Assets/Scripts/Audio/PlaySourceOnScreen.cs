using UnityEngine;
using System.Collections;
[RequireComponent (typeof(BoxCollider2D))]
public class PlaySourceOnScreen : MonoBehaviour {

	[HideInInspector] public AudioSource [] sound;

	void Awake () {
		sound = GetComponentsInChildren <AudioSource> ();
		for (int i = 0; i < sound.Length; i++)
			sound [i].loop = true;
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.E))
			PlaySound (true);
	}
	void OnTriggerEnter2D (Collider2D coll) {
		Debug.Log ("Entered");
		if (coll.CompareTag ("Player"))
			PlaySound (true);
	}
	void OnTriggerExit2D (Collider2D coll) {
		if (coll.CompareTag ("Player"))
			PlaySound (false);
	}
	void PlaySound (bool play) {
		if (play) {
			for (int i = 0; i < sound.Length; i++)
				sound [i].Play ();
		} else {
			for (int i = 0; i < sound.Length; i++)
				sound [i].Stop ();
		}
	}
}
