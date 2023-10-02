using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	private float time;
	private TMP_Text guiTime;

	void Start() {
		guiTime = GetComponent<TMP_Text>();
		time = 20;
	}

	private void Update() {
		timerTick();
		updateGUITime();

		if (timeUp()) {
			SceneManager.LoadScene("SampleScene");
		}
	}

	public void timerTick() {
		time -= Time.deltaTime;
	}

	public void updateGUITime() {
		guiTime.text = "Time: " + time;
	}

	public bool timeUp() {
		if (time <= 0) { return true; }

		return false;
	}
}
