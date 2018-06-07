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

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
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

	}

	void Update () {
		Debug.Log(brickSprites);
		if (health == 3) {
			spriteRenderer.sprite = brickSprites[2];
		} else if (health == 2) {
			spriteRenderer.sprite = brickSprites[1];
		} else if (health == 1) {
			spriteRenderer.sprite = brickSprites[0];
		} else if (health <= 0) {
			rend.enabled = false;
			Destroy(gameObject);
		}
	}
}
