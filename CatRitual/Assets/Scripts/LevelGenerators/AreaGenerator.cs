using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AreaGenerator
: MonoBehaviour {

	public int seed = 12;
	public bool updateArea;
	public int numberOfItems = 50;
	public float zPos = 4;

	public Sprite [] sprites;
	public Vector2 extents = new Vector2 (15,15);

	void Update () {
		if (updateArea) {
			updateArea = false;
			for (int i = transform.childCount - 1; i >= 0; i--) {
				DestroyImmediate (transform.GetChild (i).gameObject);
			}
			Random.seed = seed;
			for (int i = 0; i < numberOfItems; i++) {
				Vector3 localPosition = new Vector3 (Random.Range (-extents.x,extents.x), Random.Range (-extents.y,extents.y), zPos);
				SpriteRenderer spriteRend = new GameObject ("inst").AddComponent<SpriteRenderer> ();
				spriteRend.transform.SetParent (transform);
				spriteRend.transform.localPosition = localPosition;
				spriteRend.sprite =	sprites[Random.Range (0,sprites.Length)];
			}
		}
	}
	void OnDrawGizmosSelected () {
		Gizmos.DrawWireCube (transform.position, extents * 2);
	}
}
