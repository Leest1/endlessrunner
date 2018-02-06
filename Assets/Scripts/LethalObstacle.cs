using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalObstacle : MonoBehaviour {

	public AudioSource impact;
	private EndMenu end;

	void Start () {
		end = FindObjectOfType<EndMenu> ();
		impact = GetComponent<AudioSource> ();
		if (GlobalController.Instance.normal) {
			BoxCollider2D coll = GetComponent<BoxCollider2D> ();
			coll.isTrigger = true;
		}
	}

	void OnCollisionStay2D (Collision2D collision) {
		if (!GlobalController.Instance.normal) {
			impact.Play ();
			Collider2D other = collision.collider;
			if (other.name == "dog(Clone)") {
				Time.timeScale = 0f;
				end.endGame ();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (GlobalController.Instance.normal) {
			if (other.name == "cat(Clone)" || other.name == "dog(Clone)") {
				impact.Play ();
				end.loseLife ();
			}
		}
	}

}
