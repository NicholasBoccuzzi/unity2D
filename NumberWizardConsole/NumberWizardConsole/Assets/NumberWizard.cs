using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int max = 1000;
		int min = 1;

		Debug.Log("Welcome to Number Wizard!");
		Debug.Log("Pick a number, but don't tell me what it is!");
		Debug.Log("Highest number is: " + max);
		Debug.Log("Lowest number is: " + min);
		Debug.Log("Tell me if your number is higher or lower than" + (max/min));
		Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Debug.Log("You Win!");
		
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Debug.Log("You Win!");

		}

		if (Input.GetKeyDown(KeyCode.Return)) {
			Debug.Log("You Win!");
		}
	}
}
