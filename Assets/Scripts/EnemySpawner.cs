using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float spawnInterval = 5f;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 0, spawnInterval);
	}
	
	// Update is called once per frame
	void Spawn() {
		Instantiate(enemy, transform.position, transform.rotation, GameObject.Find("Enemies").transform);
	}
}
