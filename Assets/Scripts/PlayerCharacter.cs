using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	private int health;

	void Start() {
		health = 5;
	}

	public void TakeDamage(int damage) {
		health -= damage;
		if (health > 0) {
			Debug.Log ("Health: " + health);
		} else {
			Die ();
		}
	}

	private void Die() {
		Debug.Log ("You have died.");
	}
}
