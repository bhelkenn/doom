using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	private bool _alive;
	[SerializeField] private GameObject fireballPrefab = null;
	private GameObject fireball;
	void Start() {
		_alive = true;
	}

	void Update() {
		if (_alive) {
			transform.Translate (0, 0, speed * Time.deltaTime);
		}

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerCharacter> ()) {
				if (fireball == null) {
					fireball = Instantiate (fireballPrefab) as GameObject;
					fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
					fireball.transform.rotation = transform.rotation;
				}
			}
			if (hit.distance < obstacleRange) {
				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);
			}
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
