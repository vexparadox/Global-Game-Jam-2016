using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]
public class PlaySourceOnScreen : MonoBehaviour {

	[HideInInspector] public Renderer renderer;
	[HideInInspector] public AudioSource sound;

	void Awake () {
		renderer = GetComponentInChildren<Renderer> ();
		sound = GetComponentInChildren<AudioSource> ();
		sound.loop = true;
	}
	void Update () {
		CameraScript.addOnEnterNewScreen (OnEnterNewPlace);
	}
	void OnEnterNewPlace () {
		if (renderer.isVisible)
			sound.Play ();
		else
			sound.Stop ();

	}
}
