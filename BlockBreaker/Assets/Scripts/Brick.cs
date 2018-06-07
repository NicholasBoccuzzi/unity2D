using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int health;
	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		health -= 1; 
		GetComponent<AudioSource> ().Play();
	}

	void Update () {
		if (health <= 0) {
			Object.Destroy(gameObject);
		}
	}
}
