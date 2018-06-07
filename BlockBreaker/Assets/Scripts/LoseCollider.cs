using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager LevelManager;

	void Start() {
		LevelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnCollisionEnter2D(Collision2D collision) {
	}

	void OnTriggerEnter2D(Collider2D collider) {
		LevelManager.LoadLevel("Lose");
	}
}
