using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(AudioSource))]
public class BasePowerup : MonoBehaviour {

	public float dropSpeed = 1;
	public AudioClip sound;

	void Start () {
		GetComponent<AudioSource>().playOnAwake = false;
	}
	
	IEnumerator OnTriggerEnter2D(Collider2D other) {
		if( other.name == "Paddle") {
			OnPickup();

			GetComponent<Collider2D>().enabled = false;
			GetComponent<Renderer>().enabled = false;

			GetComponent<AudioSource>().pitch = Time.timeScale;

			GetComponent<AudioSource>().PlayOneShot(sound);
			yield return new WaitForSeconds(sound.length);
		}
	}

	protected virtual void OnPickup() {

	}
}
