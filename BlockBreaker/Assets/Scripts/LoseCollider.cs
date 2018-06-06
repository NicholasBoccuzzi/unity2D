using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	public LevelManager LevelManager;

	void OnCollisionEnter2D(Collision2D collision) {
		print("Collision");

	}

	void OnTriggerEnter2D(Collider2D collider) {
		print ("Trigger");
		LevelManager.LoadLevel("Lose");
	}
}
