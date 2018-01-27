using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Wall : MonoBehaviour {

	public AudioClip sound;

	void OnCollisionEnter2D(Collision2D other)
	{
		GetComponent<AudioSource>().PlayOneShot(sound);
	}
}
