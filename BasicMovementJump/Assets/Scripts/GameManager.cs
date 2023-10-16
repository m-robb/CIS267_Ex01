using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject player;

	private PlayerScore playerScore;
	private bool gameOver;


	private void Start() {
		playerScore = player.GetComponent<PlayerScore>();
		setGameOver(false);

		Debug.Log("High Score: " + SaveData.loadScore());
	}

	public bool getGameOver() {
		return gameOver;
	}

	public void setGameOver(bool g) {
		gameOver = g;
		evaluateGameState();
	}

	public void evaluateGameState() {
		if (gameOver) {
			SaveData.saveScore(playerScore.getScore());
			Time.timeScale = 0.0f;
		}
		else {
			Time.timeScale = 1.0f;
		}
	}
}