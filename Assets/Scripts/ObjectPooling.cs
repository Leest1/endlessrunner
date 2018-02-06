using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

	public GameObject poolObject;
	public int amount;

	List<GameObject> objects;

	void Start () {
		objects = new List<GameObject> ();

		for (int i = 0; i < amount; i++) {
			GameObject obj = (GameObject)Instantiate (poolObject);
			obj.SetActive (false);
			objects.Add (obj);

		}
	}

	public GameObject getPooledObject () {
		for (int i = 0; i < objects.Count; i++) {
			if (!objects [i].activeInHierarchy) {
				return objects [i];
			}
		}
		GameObject obj = (GameObject)Instantiate (poolObject);
		obj.SetActive (false);
		objects.Add (obj);
		return obj;
	}
}
