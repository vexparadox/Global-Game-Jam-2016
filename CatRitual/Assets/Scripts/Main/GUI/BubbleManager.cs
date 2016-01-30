using UnityEngine;
using System.Collections;
namespace Game.Bubble {
	public class BubbleManager : MonoBehaviour {
	
		[SerializeField] public float timeBetweenBubbles = 0.4f;
	
		[HideInInspector] public int indexOfCurrentBubble = 0;
		[HideInInspector] public float timeOfLastBubbleCreation;
	
		void Start () {
			timeOfLastBubbleCreation = Time.time;
		}
	
		void Update () {
			if (Time.time > timeOfLastBubbleCreation + timeBetweenBubbles) {
				if (indexOfCurrentBubble < transform.childCount)
					transform.GetChild (indexOfCurrentBubble++).gameObject.SetActive (true);
				timeOfLastBubbleCreation = Time.time;
			}
		}
	}
}