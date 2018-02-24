using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes {
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXandY;
	public float HorizontalSensitivity = 9.0f;
	public float VerticalSensitivity = 9.0f;
	public float minVertical = -45.0f;
	public float maxVertical = 45.0f;

	private float rotationX = 0;
	private float rotationY = 0;
	void Update() {		
		if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * HorizontalSensitivity, 0);
		} else if (axes == RotationAxes.MouseY) {
			VerticalLook ();

			rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
		} else {
			VerticalLook ();

			float delta = Input.GetAxis ("Mouse X") * HorizontalSensitivity;
			rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
		}
	}

	void VerticalLook() {
		rotationX -= Input.GetAxis ("Mouse Y") * VerticalSensitivity;
		rotationX = Mathf.Clamp (rotationX, minVertical, maxVertical);
	}
}
