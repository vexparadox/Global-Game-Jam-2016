using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {

	public static AudioClip [] footSteps;

	[HideInInspector] public static AudioSource audioSource;

	public void Awake () {
		if (footSteps == null)
			footSteps = Resources.LoadAll <AudioClip> ("AudioClips/FootSteps");

		if (!(audioSource = GetComponent<AudioSource> ()))
			audioSource = gameObject.AddComponent <AudioSource> ();
	}


	public static void PlayFootStep () {
		if (footSteps == null)
			new GameObject ("SoundControlers").AddComponent <SFX> ();
		PlayClip (footSteps [Random.Range (0, footSteps.Length)]);
	}
	public static void PlayClip (AudioClip clip) {
		if (audioSource == null)
			new GameObject ("SoundControlers").AddComponent <SFX> ();

		audioSource.clip = clip;
		audioSource.Play ();
	}
}
