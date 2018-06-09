using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public string lev;
	public Brick brick;
	private PaddleMovement paddleMovement;

	void Update () {
		if (lev == "Level_01" || lev == "Level_02") {
			Cursor.visible = false;
		} else if (!Cursor.visible) {
			Cursor.visible = true;
		}

		BrickDestroyed();
	}

	void Start () {
		paddleMovement = GameObject.FindObjectOfType<PaddleMovement>();
		print(paddleMovement);
	}

	public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
	}

	public void QuitLevel(string name) {
		Application.Quit();
	}

	public void LoadNextLevel() {
		if (paddleMovement.autoPlay) {
			SceneManager.LoadScene("Level_01");
		} else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void BrickDestroyed() {
		if (Brick.brickCount <= 0)  {
			if (lev == "Level_01" || lev == "Level_02") {
				LoadNextLevel();
			}
		}
	}
}
