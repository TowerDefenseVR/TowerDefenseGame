using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float spawnInterval = 5f;
	
	void Start () {
		InvokeRepeating("SpawnEnemy", 0, spawnInterval);
	}
	
	// Update is called once per frame
	void SpawnEnemy() {
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, GameObject.Find("Enemies").transform);
	}
}
