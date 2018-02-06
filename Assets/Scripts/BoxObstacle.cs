using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObstacle : MonoBehaviour {

	public AudioSource impact;
	private EndMenu end;

	void Start () {
		end = FindObjectOfType<EndMenu> ();
		impact = GetComponent<AudioSource> ();
	}

	void OnCollisionStay2D (Collision2D collision) {
		Collider2D other = collision.collider;
		if (other.name == "cat(Clone)" || other.name == "dog(Clone)") {
			Vector3 contact = collision.contacts [0].point;
			Vector3 center = other.bounds.center;

			bool right = contact.x > center.x;

			if (right) {
				impact.Play ();
				if (!GlobalController.Instance.normal)
					end.endGame ();
				else {
					BoxCollider2D[] coll = GetComponents<BoxCollider2D> ();
					for (int i = 0; i < coll.Length; i++) {
						coll [i].isTrigger = true;
						StartCoroutine (Count (coll [i]));
					}
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (GlobalController.Instance.normal) {
			if (other.name == "catrun_0" || other.name == "dogrun_0") {
				impact.Play ();
				end.loseLife ();
			}
		}
	}

	IEnumerator Count(BoxCollider2D other){
		yield return new WaitForSeconds (1.65f);
		other.isTrigger = false;
	}
}
