using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
	public int collectableValue;
	public GameObject playerObject; //We need a reference to PlayerScore.cs script. That script is attached to the player.
	private PlayerScore gameScore; //This is the PlayerScore.cs script.


	// Start is called before the first frame update
	void Start() {
		//Find the object that has the PlayerScore.cs script attached to it.
		//You can use .find but should avooid it if you can.
		//By making the playerObject variable public, we can use the Unity Editor to link the variable with the object.
		//This will allow us to access the script.

		//Can do this, but it is not required at this time.
		//This will search the entire hierarchy until it finds an object called Player.
		//playerObject = GameObject.Find("Player");

		//Cannot just use GetComponent because PlayerScore.cs is not attached to the collectable.
		gameScore = playerObject.GetComponent<PlayerScore>();
	}

	// Update is called once per frame
	void Update() {}


	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			gameScore.setPlayerScore(collectableValue);
			Destroy(this.gameObject);
		}
	}
}
