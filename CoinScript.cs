using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	public int score = 0;
	AudioSource src;

	void Start() {
		src = GetComponent<AudioSource>() as AudioSource;
	}

	void OnTriggerEnter2D(Collider2D other) {
		gameObject.SetActive(false);
		++score;

		AudioSource.PlayClipAtPoint(src.clip, transform.position, 0.1f);
	}
}