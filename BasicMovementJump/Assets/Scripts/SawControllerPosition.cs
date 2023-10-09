using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControllerPosition : MonoBehaviour {
	public float movementSpeed;
	public float distance;

	private float starting_position;
	private bool direction;
	

	private void Start() {
		starting_position = transform.position.y;

		direction = false;
	}

	private void Update() {
		if (transform.position.y <= starting_position - distance) { direction = true; }
		else if (transform.position.y >= starting_position) { direction = false; }

		moveSaw(direction);
	}

	public void moveSaw(bool direction) {
		if (direction) {
			transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
		}
		else {
			transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag.Equals("Player")) {
			Debug.Log("dead");
		}
	}
}