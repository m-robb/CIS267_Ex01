using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	//gravity: 5
	private Rigidbody2D playerRigidBody;
	//8
	public float movementSpeed;
	private float inputHorizontal;
	//12
	public float jumpForce;
	private int numJumps;
	private int maxNumJumps;
	// Start is called before the first frame update
	void Start() {
		playerRigidBody = GetComponent<Rigidbody2D>();
		maxNumJumps = 1;
		numJumps = 0;
	}

	// Update is called once per frame
	void Update() {
		movePlayerLateral();
		jump();
	}

	private void movePlayerLateral() {
		inputHorizontal = Input.GetAxisRaw("Horizontal");

		playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);

		flipPlayer();
	}

	private void flipPlayer() {
		if (inputHorizontal > 0) {
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if (inputHorizontal < 0) {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
	}

	private void jump() {
		if (Input.GetKeyDown(KeyCode.Space) && numJumps < maxNumJumps) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);

			numJumps++;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("OB")) {
			//Need to import SceneManagement
			SceneManager.LoadScene("SampleScene");
		}
		else if (collision.gameObject.CompareTag("Ground")) {
			numJumps = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("DoubleJump")) {
			Destroy(collision.gameObject);
			maxNumJumps = 2;
		}
		else if (collision.gameObject.CompareTag("CoinCollectable")) {
			/* Get value of collectable, add it to the score. */
			int collectableValue = collision.GetComponent<Collectable>().getCollectableValue();
			this.GetComponent<PlayerScore>().setPlayerScore(collectableValue);

			/* Destroy the collectable. */
			collision.GetComponent<Collectable>().destroyCollectable();

		}
	}
}
