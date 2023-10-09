using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour {
	public float movementSpeed;

	private utimer timer;
	private bool direction;

	private void Start() {
		timer.duration = 2;
		timer.start_time = Time.time;

		direction = false;
	}

	private void Update() {
		moveSaw(direction);

		if (timer.done(Time.time)) {
			direction = !direction;
			timer.start_time = Time.time;
		}
	}

	public void moveSaw(Boolean direction) {
		if (direction) {
			transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
		} else {
			transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
		}
	}
}
