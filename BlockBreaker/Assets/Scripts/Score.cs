using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int currentScore;
	// Use this for initialization
	void Start () {
	}

	public void addToScore () {
		currentScore += 25;
		UpdateScore();
	}
	
	// Update is called once per frame
	void UpdateScore () {
		scoreText.text = currentScore.ToString();
	}
}
