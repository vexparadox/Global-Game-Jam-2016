using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetUVToWorldSpace : MonoBehaviour {

	MeshFilter filter;
	[SerializeField] public float zoom = 50;

	void Awake () {
		filter = GetComponent<MeshFilter> ();
	}
	void Update () {
		Mesh repeatingMesh = filter.sharedMesh;
		Vector2 [] uvs = repeatingMesh.uv;
		Vector3 [] verts = repeatingMesh.vertices;

		for (int i = 0; i < verts.Length; i++) {
			Vector3 pos = transform.TransformPoint (verts[i]) / zoom;
			uvs[i] = (Vector2)pos;
		}
		repeatingMesh.uv = uvs;
	}
}
