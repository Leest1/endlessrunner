using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour {

	public Text score;
	public Text difficulty;

	public AudioSource sound;
	public GameObject menu;

	public GameObject controls;
	public GameObject multiMenu;
	public GameObject hostMenu;
	public GameObject connectMenu;

	public GameObject dropDifficulty;
	public GameObject dropAnimal;

	public InputField ip;
	public GameObject hostText;

	public GameObject cat;
	public GameObject dog;
	public NetworkManager networkManager;

	void Start () {
		Screen.SetResolution (500, 629, false);
		Time.timeScale = 1f;
		QualitySettings.antiAliasing = 0;

		if (PlayerPrefs.HasKey ("HighScore")) {
			score.text = "High Score: " + PlayerPrefs.GetInt ("HighScore");
		} else
			PlayerPrefs.SetInt ("HighScore", 0);

		GlobalController.Instance.normal = true;
		GlobalController.Instance.multiplayer = false;
		GlobalController.Instance.seed = -1;
	}

	void Update () {
//		if (networkManager.numPlayers == 2) {
//			hostText.GetComponent<InputField> ().text = "Player has joined!";
//		}
	}

	public void Play () {
		sound.Play ();
		GlobalController.Instance.seed = -1;
		SceneManager.LoadScene ("Play");
	}

	public void Difficulty () {
		sound.Play ();

		if (GlobalController.Instance.normal == false) {
			difficulty.text = "Normal";
			GlobalController.Instance.normal = true;
		} else {
			difficulty.text = "Hard";
			GlobalController.Instance.normal = false;
		}
	}

	public void Controls () {
		sound.Play ();
		controls.SetActive (true);
		menu.SetActive (false);
	}

	public void Back () {
		sound.Play ();
		controls.SetActive (false);
		multiMenu.SetActive (false);
		menu.SetActive (true);
		GlobalController.Instance.multiplayer = false;
	}

	public void Multiplayer () {
		sound.Play ();
		multiMenu.SetActive (true);
		menu.SetActive (false);
		GlobalController.Instance.multiplayer = true;

	}

	public void MultiBack () {
		if (NetworkServer.active && NetworkClient.active)
			networkManager.StopHost ();
		multiMenu.SetActive (true);
		connectMenu.SetActive (false);
		hostMenu.SetActive (false);
		hostText.SetActive (false);
		dropAnimal.SetActive (true);
		dropDifficulty.SetActive (true);
	}

	public void Connect () {
		multiMenu.SetActive (false);
		connectMenu.SetActive (true);
	}

	public void Host () {
		multiMenu.SetActive (false);
		hostMenu.SetActive (true);
	}

	public void HostConnect() {
		hostText.SetActive (true);
		GlobalController.Instance.normal = (dropDifficulty.GetComponent<Dropdown> ().value == 0);
		dropAnimal.SetActive (false);
		dropDifficulty.SetActive (false);

		if (dropAnimal.GetComponent<Dropdown> ().value == 0) {
			networkManager.playerPrefab = cat;
		} else {
			networkManager.playerPrefab = dog;
		}

		if (!NetworkServer.active && !NetworkClient.active)
			networkManager.StartHost ();
	}

	public void ServerConnect () {
		if (ip.text != "")
			networkManager.networkAddress = ip.text;
		if (!NetworkClient.active)
			networkManager.StartClient ();
	}
}
