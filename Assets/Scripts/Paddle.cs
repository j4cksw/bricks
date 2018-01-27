using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour {

	public AudioClip sound;

	void Update () {

		Vector3 mousePos = Input.mousePosition;
		Vector3 targetPose = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));

		this.transform.position = new Vector3(Mathf.Clamp(targetPose.x, -3.5f, 3.5f), this.transform.position.y, this.transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		GetComponent<AudioSource>().pitch = Time.timeScale;

		GetComponent<AudioSource>().PlayOneShot(sound);
	}
}
