using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level Load Requested for: " + name);
		Application.LoadLevel(name);
	}

	public void QuitLevel(string name) {
		Debug.Log("Quiting the level: " + name);
		Application.Quit();
	}
}
