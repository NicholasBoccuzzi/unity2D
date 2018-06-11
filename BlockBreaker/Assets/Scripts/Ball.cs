using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private bool autoLaunch = false;
	private PaddleMovement paddle;
	public bool started = false;
	private Rigidbody2D rigi;
	private void Awake() {
		rigi = GetComponent<Rigidbody2D>();
	}

	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleMovement>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown(0)){
				started = true;
				rigi.velocity = new Vector2 (.5f, 8f);
			}

		}
	}

	public void AutoPlayLaunch() {
		started = true;

		if (!autoLaunch) {
			rigi.velocity = new Vector2 (.5f, 8f);		
			autoLaunch = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 random = new Vector2 (Random.Range(-.3f, .3f), Random.Range(0f, .3f));

		GetComponent<Rigidbody2D>().velocity += random;
	}
}
