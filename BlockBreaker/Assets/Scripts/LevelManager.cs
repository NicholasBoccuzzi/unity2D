using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public string lev;

	void Update () {
		if (lev == "Level_01") {
			Cursor.visible = false;
		} else if (!Cursor.visible) {
			Cursor.visible = true;
		}
	}

	public void LoadLevel(string name) {
		lev = name;
		SceneManager.LoadScene(name);
	}

	public void QuitLevel(string name) {
		Application.Quit();
	}
}
