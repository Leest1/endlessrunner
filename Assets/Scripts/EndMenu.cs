using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {
	
	public GameObject cat;
	public GameObject dog;

	public bool show;
	public GameObject endMenu;
	public Text scoreText;
	public float score;

	public GameObject showInfo;
	public int lives;

	private bool invul;

	void Awake () {
		if (!GlobalController.Instance.multiplayer) {
			Instantiate (cat);
			Instantiate (dog);
		}
	}

	void Start () {
		endMenu.SetActive (show);
		score = 0;
		if (GlobalController.Instance.normal == true)
			lives = 5;
		else
			lives = 1;
	}

	void Update () {
        if (GlobalController.Instance.normal)
            score += 0.05f;
        else
            score += 0.1f;

		if (Input.GetKeyDown (KeyCode.Return) && show)
			startNew ();
	}

	public void endGame () {
		Time.timeScale = 0f;
		show = true;
		scoreText.text = "Score: " + (int) score;
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", (int) score);
			PlayerPrefs.Save ();
		}
		showInfo.SetActive (false);
		endMenu.SetActive (show);
	}

	public void loseLife () {
		if (!invul) {
			lives -= 1;
			if (lives == 0)
				endGame();
			else {
				invul = true;
				StartCoroutine (Invulnurable ());
			}
		}
	}

	IEnumerator Invulnurable () {
		yield return new WaitForSeconds (2f);
		invul = false;
	}

	public void startNew () {
		Time.timeScale = 1f;
		if (GlobalController.Instance.multiplayer) {
		} else {
			SceneManager.LoadScene ("Play");
		}
	}

	public void homePage () {
		SceneManager.LoadScene ("Home");
	}
}
