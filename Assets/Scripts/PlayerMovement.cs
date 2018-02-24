using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float gravity = -9.8f;

	private CharacterController charController;
	void Start () {
		charController = GetComponent<CharacterController> ();
	}

	void FixedUpdate () {
		float moveStraight = Input.GetAxis ("Vertical") * speed;
		float moveSideways = Input.GetAxis ("Horizontal") * speed;

		Vector3 movement = new Vector3 (moveSideways, gravity, moveStraight);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		charController.Move (movement);
	}
}
