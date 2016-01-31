using UnityEngine;
using System.Collections;

public class zPosSetter : MonoBehaviour {

	public const float maxZPos = 8f;
	public const float minZPos = 6f;

	public const float maxYPos = 150f;
	public const float minYPos =-150f;

	[SerializeField] public float yOffset;
	void LateUpdate () {
		Vector3 pos = transform.position;
		pos.z = (maxZPos - minZPos) * ((maxYPos - pos.y + yOffset) / (minYPos - maxYPos));
		transform.position = pos;
	}
}
