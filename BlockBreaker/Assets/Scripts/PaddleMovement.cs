using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

	float xValue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos = new Vector3 ( 8, this.transform.position.y, 0f);
		xValue = Mathf.Clamp(Input.mousePosition.x/Screen.width * 16, .5f, 15.5f);

		paddlePos.x = xValue;

		this.transform.position = paddlePos;
	}
}
