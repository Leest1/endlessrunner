using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBackground : MonoBehaviour {

	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material material = mr.material;
		Vector2 offset = material.mainTextureOffset;

		offset.x += Time.deltaTime/100;
		material.mainTextureOffset = offset;
	}
}
