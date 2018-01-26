using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Animation))]
public class Brick : MonoBehaviour {

	public int maxHits;
	public int timesHit;
	private bool brickIsDestroyed=false;

	public AudioClip sound;
	public float pitchStep = 0.05f;
	public float maxPitch = 1.3f;

	public static float pitch = 1;

	public bool fallDown = false;

	[HideInInspector]
	public bool blockIsDestroyed = false;
	private Vector2 velocity = Vector2.zero;

	void Start() {
		timesHit = 0;
	}

	void Update() {
		if( fallDown && velocity != Vector2.zero ) {
			Vector2 pos = (Vector2)transform.position;
			pos += velocity * Time.deltaTime;
		}
	}
	
	void OnBecameInvisible() {
		blockIsDestroyed = true;
		Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		timesHit++;
		print ("Ouch you hit me this many times:"+timesHit);

		print("Playing brick sound!");
		pitch += pitchStep;

		if( pitch > maxPitch )
			pitch = 1;
		
		GetComponent<AudioSource>().pitch = pitch;
		GetComponent<AudioSource>().PlayOneShot(sound);

		StartCoroutine(OnCollisionExit2D(other));
	}

	private IEnumerator OnCollisionExit2D(Collision2D other)
	{
		if( timesHit == maxHits) {
			print("Destroyed on Exit!");

			print("Play Woggle!");
			GetComponent<Collider2D>().enabled = false;

			GetComponent<Animation>().Play();

			yield return new WaitForSeconds(GetComponent<Animation>()["Woggle"].length);

			if( fallDown ) {
				print("Falling!");
				velocity = new Vector2(0, Random.Range(1, 12.0f) * -1);
			} else {
				GetComponent<Renderer>().enabled = false;
			}
			Destroy(gameObject);
		} else {
			print("Max hits not reached");
		}
	}
}
