using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour {

	public EndMenu end;
	public Text score;

	void Start () {
		end = FindObjectOfType<EndMenu> ();
	}

	void Update () {
		score.text = "Score: " + (int) end.score;
	}
}
