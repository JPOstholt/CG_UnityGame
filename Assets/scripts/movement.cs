using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public float xInput;
	public float zInput;
	[Range(0,100)]
	public float moveSpeed;
	public float jumpForce;
	public int jumps = 0;
	public int maxJumps = 1;
	public float groundCheckRadius;
	public LayerMask ground;
	public float airControl;
	public Vector3 velocity;
	public int maxSpeed;
	public bool nitro;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		velocity = GetComponent<Rigidbody> ().velocity;

		xInput = Input.GetAxis ("Horizontal");
		zInput = Input.GetAxis ("Vertical");

		if ((Mathf.Abs (velocity.x) < maxSpeed) ) {

			moveX ();

		} 
		if (( Mathf.Abs (velocity.z) < maxSpeed)) {
			
			moveZ ();
		}

		if ((Input.GetKeyDown(KeyCode.JoystickButton0)|| Input.GetKeyDown (KeyCode.Space) ) && jumps > 0) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jumpForce, 0));
			jumps--;
		}


		if (Physics.OverlapSphere (transform.position, groundCheckRadius, ground).Length > 0) {

			jumps = maxJumps;

		}

		if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.JoystickButton1)) {
			if (nitro) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, 2000));
				nitro = false;
				StartCoroutine ("nitroTime");
			}
		}

		if (nitro) {

			//GetComponent<MeshRenderer> ().material.color = Color.cyan;

		} else {
			//GetComponent<MeshRenderer> ().material.color = Color.white;

		}

	}

 	IEnumerator nitroTime(){

		//yield return new WaitForSeconds (3);

		//nitro = false;

		yield return new WaitForSeconds (5);

		nitro = true;

	}

	void moveX () {
		if (jumps > 0) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (xInput, 0,0) * moveSpeed);
		} else {

			GetComponent<Rigidbody> ().AddForce (new Vector3 (xInput, 0, 0) * moveSpeed * airControl);
		}
	}

	void moveZ () {
		if (jumps > 0) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, zInput) * moveSpeed);
		} else {

			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, zInput) * moveSpeed * airControl);
		}
	}



}
