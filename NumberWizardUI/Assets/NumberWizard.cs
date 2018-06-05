using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
		int max;
		int min;
		int guess;
		public Text text;
		int maxGuesses = 6;

	// Use this for initialization
	void Start () {
		StartGame();
	}

	public void GuessHigher() {
			min = guess;
			NextGuess();
	}

	public void GuessLower() {
			max = guess;
			NextGuess();	
	}

	void StartGame () {
		max = 1000;
		min = 1;
		guess = Random.Range(min, max);
		text.text = "My first guess is: " + guess;
		max = max + 1;
	}

	void NextGuess () {
		guess = (max + min)/2;
		maxGuesses -= 1;
		text.text = ("Is your number: " + guess + "?");
		if (maxGuesses <= 0) {
			Application.LoadLevel("Win");
		}
	}
}
