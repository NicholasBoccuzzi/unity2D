using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

	public Ball ball;
	private bool started = false;
	float xValue;
	public LevelManager lev;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (started == false) {
			started = ball.started;		
		}

		Vector3 paddlePos = new Vector3 ( 8, this.transform.position.y, 0f);

		if (lev.lev == "Level_02") {
			xValue = (Input.mousePosition.x/Screen.width * -16) + 16;
			paddlePos.x = xValue;	
			this.transform.position = paddlePos;
		} else {
			xValue = Input.mousePosition.x/Screen.width * 16;
			paddlePos.x = xValue;				
			this.transform.position = paddlePos;
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (started) {
			GetComponent<AudioSource> ().Play();
		}
	}

}
