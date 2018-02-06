using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float speed;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask ground;

	public KeyCode jump;
	public AudioSource sound;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool grounded;
	private bool secondJump;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, ground);
	}
		
	void Update () {
		anim.SetBool ("grounded", grounded);

		if (Input.GetKeyDown (jump)) {
			if (secondJump) {
				if (!GlobalController.Instance.multiplayer) {
					Jump ();
					secondJump = false;
				} else {
					Jump ();
					secondJump = false;
				}
			}
			if (grounded) {
				if (!GlobalController.Instance.multiplayer) {
					Jump ();
					secondJump = true;
				} else {
					Jump ();
					secondJump = true;
				}
			}
		}

		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
	}

	public void Jump () {
		sound.Play ();
		rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
	}
}
