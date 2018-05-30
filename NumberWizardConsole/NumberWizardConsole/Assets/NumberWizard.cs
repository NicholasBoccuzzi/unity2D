using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
		int max = 1000;
		int min = 1;
		int guess = 500;
	// Use this for initialization
	void Start () {
		max = max + 1;
		Debug.Log("Welcome to Number Wizard!");
		Debug.Log("Pick a number, but don't tell me what it is!");
		Debug.Log("Highest number is: " + max);
		Debug.Log("Lowest number is: " + min);
		Debug.Log("Tell me if your number is higher or lower than " + guess);
		Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Debug.Log("So your number is higher than " + guess + "? Hmm, let me think...");
			min = guess;
			guess = (max + min)/2;
			Debug.Log("Is your number, " + guess + "?");
			
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Debug.Log("So your number is lower than " + guess + "? Hmm, let me think...");
			max = guess;
			guess = (max + min)/2;
			Debug.Log("Is your number, " + guess + "?");
	
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			Debug.Log("I did it! Your number is " + guess + "!");
		}
	}
}
