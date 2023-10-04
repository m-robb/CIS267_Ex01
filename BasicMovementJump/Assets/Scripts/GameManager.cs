using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private bool gameOver;


	private void Start() {
		/* gameOver = false; */
		setGameOver(false);
	}

	public bool getGameOver() { return gameOver; }
	public void setGameOver(bool g) {
		gameOver = g;
		evaluateGameState();
	}

	public void evaluateGameState() {
		if (gameOver) {
			Time.timeScale = 0.0f;
		}
		else {
			Time.timeScale = 1.0f;
		}
	}
}