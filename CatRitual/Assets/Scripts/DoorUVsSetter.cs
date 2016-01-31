using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent (typeof (ZoneChange))]
public class DoorUVsSetter : MonoBehaviour {
	public MeshFilter targetFilter;
	public MeshFilter meshFilter;

	void Start () {
		MeshFilter meshFilter = GetComponent<MeshFilter> ();
		if (meshFilter.sharedMesh != null && meshFilter.sharedMesh.name == "newQuadMeshu") {
			DestroyImmediate (meshFilter.sharedMesh);
		}
		meshFilter.sharedMesh = Instantiate (targetFilter.sharedMesh);
		meshFilter.sharedMesh.name = "newQuadMeshu";

		Update ();
		if (Application.isPlaying) {
			Destroy(this);
		}
	}
	
	void Update () {
		Bounds bound = GetComponent<Renderer> ().bounds;

		Vector2 bottomCenterPosition = new Vector2 (bound.center.x, bound.center.y - bound.extents.y);

		Mesh thisMesh	 = GetComponent <MeshFilter> ().sharedMesh;
		Vector3 [] verts = thisMesh.vertices;
		Vector2 [] uvs   = new Vector2[verts.Length];

		for (int i = 0; i < verts.Length; i++) {
			Vector2 localPos = targetFilter.transform.InverseTransformPoint (GetComponent<ZoneChange> ().changeLocation.transform.position + 
			                                                                 transform.TransformPoint (verts[i]) - (Vector3)bottomCenterPosition);
			localPos += new Vector2 (0.5f, 0.5f);
			uvs [i] = localPos;
		}
		thisMesh.uv = uvs;
	}
}
