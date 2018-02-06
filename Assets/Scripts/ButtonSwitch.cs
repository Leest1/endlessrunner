using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour {

	public Sprite off;
	public Sprite obstacleOff;
	public GameObject obstacle;
	public AudioSource click;

	private SpriteRenderer rend;
	private Sprite buttonOn;
	private Sprite obstacleOn;

	void Start () {
		rend = GetComponent<SpriteRenderer> ();
		buttonOn = rend.sprite;
		obstacleOn = obstacle.GetComponent<SpriteRenderer> ().sprite;
		click = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		click.Play ();
		rend.sprite = off;
		if (obstacle.name == "lazer_on") {
			obstacle.GetComponent<SpriteRenderer> ().sprite = obstacleOff;
			obstacle.GetComponent<BoxCollider2D> ().enabled = false;
			StartCoroutine (Lazer ());
		} else if (obstacle.name == "stool") {
			obstacle.SetActive (true);
			StartCoroutine (Lockers ());
        }
        else if (obstacle.name == "door") {
            obstacle.GetComponent<SpriteRenderer>().sprite = obstacleOff;
            obstacle.GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine (Door ());
        }
	}

	IEnumerator Lazer () {
		yield return new WaitForSeconds (1.65f);
		rend.sprite = buttonOn;
		obstacle.GetComponent<SpriteRenderer> ().sprite = obstacleOn;
		obstacle.GetComponent<BoxCollider2D> ().enabled = true;
	}

	IEnumerator Lockers () {
		yield return new WaitForSeconds (1.65f);
		rend.sprite = buttonOn;
		obstacle.SetActive (false);
	}

    IEnumerator Door() {
        yield return new WaitForSeconds (1.65f);
        rend.sprite = buttonOn;
        obstacle.GetComponent<SpriteRenderer>().sprite = obstacleOn;
        obstacle.GetComponent<BoxCollider2D>().enabled = false;
    }
}
