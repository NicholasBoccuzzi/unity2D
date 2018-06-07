using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int health;
	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("Hit");
		health -= 1; 
	}

	void Update () {
		if (health <= 0) {
			Debug.Log("this should be deleted");
			Object.Destroy(gameObject);
		}
	}
}
