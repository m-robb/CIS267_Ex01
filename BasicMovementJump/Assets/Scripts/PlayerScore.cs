using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Attached to the player.
public class PlayerScore : MonoBehaviour {
	private int playerScore;
	public TMP_Text guiScore;


	// Start is called before the first frame update
	void Start() {
		playerScore = 0;
	}

	// Update is called once per frame
	void Update() {}


	public int getScore() { return playerScore; }

	public void setPlayerScore(int val) {
		playerScore += val;
		guiScore.text = "Score: " + playerScore;
		Debug.Log("Score: " + playerScore);
	}
}
