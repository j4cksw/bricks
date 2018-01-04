using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

	private Ball ball;
	private GameManager gameManager;

	IEnumerator Pause() {
		print("Before Waiting 2 seconds");

		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.SwitchState(GameState.Failed);
		
		yield return new WaitForSeconds(2);

		ball = GameObject.FindObjectOfType<Ball>();
		ball.gameStarted = false;

		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		print("After Waiting 2 seconds");
	}

	void OnTriggerEnter2D(Collider2D other) {
		print("Lost triggered");

		StartCoroutine(Pause());
	}
}
