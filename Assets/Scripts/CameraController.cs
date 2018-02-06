using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private PlayerController animal;

	private Vector3 lastPosition;
	private float distance;
	private float proportion;

	void Start () {
		animal = FindObjectOfType<PlayerController> ();
		lastPosition = animal.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distance = animal.transform.position.x - lastPosition.x;
		transform.position = new Vector3 (transform.position.x + distance, transform.position.y, transform.position.z);
		lastPosition = animal.transform.position;
	}
}
