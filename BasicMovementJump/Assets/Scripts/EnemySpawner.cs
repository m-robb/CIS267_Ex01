using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject[] enemies;
	public GameObject[] spawn_locations;

	private void Start() {
		spawn_enemies();
	}

	public void spawn_enemies() {
		//int random_index;
		//GameObject spawned_prefab;
		
		for (int i = 0; i < spawn_locations.Length; ++i) {
			//random_index = Random.Range(0, enemies.Length);
			//spawned_prefab = Instantiate(enemies[random_index]);
			//spawned_prefab = Instantiate(enemies[random_index], spawn_locations[i].transform);

			//spawned_prefab.transform.position = spawn_locations[i].transform.position;

			//Instantiate(enemies[Random.Range(0, enemies.Length)], spawn_locations[i].transform);

			Instantiate(enemies[Random.Range(0, enemies.Length)], spawn_locations[i].transform.position, Quaternion.identity);
		}
	}
}