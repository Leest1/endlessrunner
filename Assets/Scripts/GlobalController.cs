using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour {

	public static GlobalController Instance;

//	multiplayer stuff
	public bool multiplayer = false;
	public int seed = -1;

//	normal stuff
	public int highScore;
	public bool normal;

	void Awake () {
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != null) {
			Destroy (gameObject);
		}
	}

	public void StartGame () {
		SceneManager.LoadScene ("Play");
	}
}
