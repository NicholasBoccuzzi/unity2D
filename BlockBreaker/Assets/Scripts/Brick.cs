using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int health;
	private Renderer rend;
	private SpriteRenderer spriteRenderer;
	public Sprite[] brickSprites;
	public AudioClip[]  audioarray;
	public AudioSource audioSource;
	public Score score;
	private LevelManager levelManager;
	public static int brickCount = 0;
	private bool TotalBricks;
	// public GameObject glow;

	// Use this for initialization
	void Start () {
		TotalBricks = (this.tag == "TotalBricks");
		if (TotalBricks) {
			brickCount++;
		}
		rend = GetComponent<Renderer>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (health == 3) {
			audioSource.PlayOneShot(audioarray[2]);
		} else if (health == 2) {
			audioSource.PlayOneShot(audioarray[1]);			
		} else if (health == 1) {
			audioSource.PlayOneShot(audioarray[0]);
		}
		health -= 1;
		if (levelManager.lev != "Level_Auto") {
			score.addToScore();
		}
	}

	void Update () {
		if (health == 3) {
			spriteRenderer.sprite = brickSprites[2];
		} else if (health == 2) {
			spriteRenderer.sprite = brickSprites[1];
		} else if (health == 1) {
			spriteRenderer.sprite = brickSprites[0];
		} else if (health <= 0) {
			// Instantiate (glow, gameObject.transform.position, Quaternion.identity);
			rend.enabled = false;
			brickCount--;
			Destroy(gameObject);
		}
	}
}
