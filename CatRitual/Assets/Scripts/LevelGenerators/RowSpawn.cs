using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RowSpawn : MonoBehaviour {

	[SerializeField] public GameObject toRow;

	[SerializeField] public int xlength = 5;
	[SerializeField] public int ylength = 1;

	[SerializeField] public bool update;

	[SerializeField] public int seed = 5;
	[SerializeField] public Vector2 minRandom;
	[SerializeField] public Vector2 maxRandom;

	[SerializeField] public Vector2 gap;
	
	void Update () {
		if (Application.isPlaying || !update || toRow == null)
			return;

		update = false;

		Vector3 startPos = transform.position;
		Bounds bound = toRow.GetComponent<Renderer> ().bounds;

		for (int i = transform.childCount - 1; i >= 0; i--) {
			if (transform.GetChild (i).name != "ignore")
				DestroyImmediate (transform.GetChild (i).gameObject);
		}
		
		Vector3 addPerBlock = bound.size + (Vector3)gap;
		Random.seed = seed;
		for (int x = 0; x < xlength; x++) {
			for (int y = 0; y < ylength; y++) {
				Vector3 spawnPos = new Vector3 (x * addPerBlock.x, y * addPerBlock.y) + startPos;
				spawnPos += new Vector3 (Random.Range (minRandom.x, maxRandom.x), Random.Range (minRandom.y, maxRandom.y));
				GameObject newObject = Instantiate (toRow, spawnPos, Quaternion.identity) as GameObject;
				newObject.name = "RowSpawned";
				newObject.transform.SetParent (transform);
			}
		}
		
	}
}
