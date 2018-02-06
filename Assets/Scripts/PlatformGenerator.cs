using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform platformPoint;
	public float distance;

	private float width;

	public ObjectPooling pool;

	void Start () {
		width = platform.GetComponent<BoxCollider2D> ().size.x * 12;
	}


	void Update () {
		if (transform.position.x < platformPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + width + distance, transform.position.y, transform.position.z);

//			Instantiate (platform, transform.position, transform.rotation);
			GameObject obj = pool.getPooledObject();
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;
			obj.SetActive (true);
		}
	}
}
