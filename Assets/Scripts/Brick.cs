using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits;
	public int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timesHit = 0;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		print("Ouch!!");
		timesHit++;

		if(timesHit == maxHits) {
			print("Destroyed!");
			Destroy(gameObject);
		}
	}
}
