using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public string lev;
	public Brick brick;
	private PaddleMovement paddleMovement = null;
	private int timer;
	private bool auto = false;
	static LevelManager instance = null;

	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Start () {
		timer = 600;
	}

	void Update () {
		if (lev == "Level_01" || lev == "Level_02") {
			if (auto == true) {
				if (paddleMovement == null) {
					paddleMovement = GameObject.FindObjectOfType<PaddleMovement>();
					paddleMovement.autoPlay = true;
				}
			}
			Cursor.visible = false;
		} else if (!Cursor.visible) {
			Cursor.visible = true;
		}



		if (lev == "Start") {
			timer -= 1;
			if (timer == 0) {
				Debug.Log("Hit zero");
				auto = true;
				LoadLevel("Level_01");
			}
		}

		BrickDestroyed();
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
			lev = "Level_01";
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
