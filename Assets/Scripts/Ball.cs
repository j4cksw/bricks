using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	public bool gameStarted = false;
	private Vector3 paddleVector;
	
	public float MinimumSpeed = 10;
	public float MaximumSpeed = 20;
	public float MinimumVerticalMovement = 0.5f;

	void Start () {
		paddleVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStarted){
			return;
		}

		this.transform.position = paddle.transform.position + paddleVector;

		if(Input.GetMouseButtonDown(0)) {
			//print("Mouse clicked");
			gameStarted = true;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2.0f, -2.0f), MinimumSpeed);
		}
		launchBall();
	}

	void launchBall() {
		Vector2 direction = GetComponent<Rigidbody2D>().velocity;
		float speed = 10f;
		direction.Normalize();

		if(direction.x > -MinimumVerticalMovement && direction.x < MinimumVerticalMovement) {
			direction.x = direction.x < 0 ? -MinimumVerticalMovement : MinimumVerticalMovement;
			direction.y = direction.y < 0 ? -1 + MinimumVerticalMovement : 1 - MinimumVerticalMovement;

			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}

		if(speed < MinimumSpeed || speed > MaximumSpeed) {
			speed = Mathf.Clamp(speed, MinimumSpeed, MaximumSpeed);
			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}
	} 
}
