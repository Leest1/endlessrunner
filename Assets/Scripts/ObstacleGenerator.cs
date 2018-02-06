using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleGenerator : MonoBehaviour {

	public Transform genPoint;
	public List<ObjectPooling> pools;

	private float distance;

	private System.Random random;
	private int seed = GlobalController.Instance.seed;

	void Start () {
		distance = 45f;

		if (seed == -1)
			random = new System.Random ();
		else
			random = new System.Random (seed);
	}

	void Update () {
		if (Time.timeSinceLevelLoad > 1 && distance > 9f) {
			distance = 50f - 8*Mathf.Log (Time.timeSinceLevelLoad);
		}

		if (transform.position.x < genPoint.position.x) {
			float randDistance = random.Next (0,5);
			transform.position = new Vector3 (transform.position.x + distance + randDistance, transform.position.y, -1);

			int rand = random.Next (0, pools.Count);
			GameObject next;

			next = pools [rand].getPooledObject ();
			next.transform.position = transform.position;
			next.transform.rotation = transform.rotation;
			next.SetActive (true);
		}
	}
}
