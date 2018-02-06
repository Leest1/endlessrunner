using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

	public GameObject background;
	public Transform genPoint;

	public List<ObjectPooling> pools;

	private float width;

	private System.Random random;
	private int seed = GlobalController.Instance.seed;

	void Start () {
		width = background.GetComponent<SpriteRenderer> ().bounds.size.x;
		if (seed == -1)
			random = new System.Random ();
		else
			random = new System.Random (seed);
	}

	void Update () {
		if (transform.position.x < genPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + width - 1, transform.position.y, transform.position.z);

			int rand = random.Next (0, 100);
			GameObject next;

			if (rand > 33)
				next = pools[0].getPooledObject ();
			else
				next = pools[1].getPooledObject ();
			
			next.transform.position = transform.position;
			next.transform.rotation = transform.rotation;
			next.SetActive (true);
		}
	}
}
