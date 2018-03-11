using UnityEngine;
using UnityEngine.UI;

public enum GameState {
	NotStarted,
	Playing,
	Completed,
	Failed
}

[RequireComponent(typeof(AudioSource))]

public class GameManager : MonoBehaviour {
	public AudioClip startSound;
	public AudioClip failedSound;

	private GameState currentState = GameState.NotStarted;

	private Brick[] allBricks;
	private Ball[] allBalls;
	private Paddle paddle;

	public float Timer=0.0f;
	private int minutes;
	private int seconds;
	public string formattedTime;

	void Start () {
		Time.timeScale = 1;

		allBricks = FindObjectsOfType(typeof(Brick)) as Brick[];
		allBalls = FindObjectsOfType(typeof(Ball)) as Ball[];

		paddle = GameObject.FindObjectOfType<Paddle>();

		print("Bricks:" + allBricks.Length);
		print("Balls:" + allBalls.Length);
		print("Paddle" + paddle);

		SwitchState(GameState.NotStarted);

	}

	void Update () {
		switch(currentState) {
			case GameState.NotStarted:
				ChangeText("Click To Begin");
				if(Input.GetMouseButtonDown(0)) {
					SwitchState(GameState.Playing);
				}
				break;
			case GameState.Playing:
				Timer += Time.deltaTime;
				minutes = Mathf.FloorToInt(Timer/60f);
				seconds = Mathf.FloorToInt(Timer-minutes * 60);
				formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

				ChangeText("Time: "+formattedTime);

				bool allBlocksDestroyed = false;

				if(FindObjectOfType(typeof(Ball)) == null) {
					SwitchState(GameState.Failed);
				}
				if(allBlocksDestroyed) {
					SwitchState(GameState.Completed);
				}
				break;
			
			case GameState.Failed:
				//print("Game failed!");
				ChangeText("You Lose :(");
				break;
			
			case GameState.Completed:
				//bool allBlocksDestroyedFinal = false;
				Ball[] others = FindObjectsOfType(typeof(Ball)) as Ball[];

				foreach(Ball other in others) {
					Destroy(other.gameObject);
				}
				break;
		}
	}

	public void SwitchState(GameState state){
		currentState = state;

		switch( currentState ) {
			default:
			case GameState.NotStarted:
				break;
			case GameState.Playing:
				GetComponent<AudioSource>().PlayOneShot(startSound);
				break;
			case GameState.Completed:
				GetComponent<AudioSource>().PlayOneShot(startSound);
				break;
			case GameState.Failed:
				GetComponent<AudioSource>().PlayOneShot(failedSound);
				break;
		}
	}

	private void ChangeText(string text) {
		GameObject canvas = GameObject.Find("Canvas");
		Text textValue = canvas.GetComponentInChildren<Text>();
		textValue.text = text;
	}
}
