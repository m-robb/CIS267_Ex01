using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	private float time;
	private TMP_Text guiTime;
	public GameObject gameManager;
	private GameManager gm;

	void Start() {
		gm = gameManager.GetComponent<GameManager>();
		guiTime = GetComponent<TMP_Text>();
		time = 5;

		updateGUITime();
	}

	private void Update() {
		timerTick();
		updateGUITime();

		if (timeUp()) {
			/* SceneManager.LoadScene("SampleScene"); */
			gm.setGameOver(true);
		}
	}

	public void timerTick() {
		time -= Time.deltaTime;
	}

	public void updateGUITime() {
		guiTime.text = "Time: " + time;
	}

	public bool timeUp() {
		/* return time <= 0 ? true : false; */
		if (time <= 0) { return true; }

		return false;
	}
}
