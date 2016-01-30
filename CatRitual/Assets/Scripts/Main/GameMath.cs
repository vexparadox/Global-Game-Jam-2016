using UnityEngine;
using System.Collections;

public class GameMath : MonoBehaviour {
	public static float Angle(Vector2 vector)
	{
		if (vector.x < 0) {
			return 360 - (Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg * -1);
		} 
		return Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
	}
}
