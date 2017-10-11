using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float spawnInterval = 5f;
	
	public int waveLimit = 10;
	private int enemyCount = 0;
	
	void Start () {
		InvokeRepeating("SpawnEnemy", 0.2f, spawnInterval);
	}

	void SpawnEnemy() {
		if(enemyCount >= waveLimit && waveLimit != 0) {
			print("-- WAVE FINISHED --");
			CancelInvoke("SpawnEnemy");
		} else if(waveLimit == 0) {
			//if wavelimit is set to 0, keep spawning enemies. For testing purposes.
			Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, transform);
		} else {
			//keep spawning until enemycount reaches wavelimit
			Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, transform);
			enemyCount++;
		}
	}
}
