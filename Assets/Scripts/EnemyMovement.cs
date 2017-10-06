using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 20f;
	private Transform target;
	private int wpIndex = 0;

	void Start() {
		target = CreateWaypoints.waypoints.transform.GetChild(wpIndex).transform;
	}

	void Update() {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
			NextWaypoint();	
		}
	}

	void NextWaypoint() {
		if(wpIndex >= CreateWaypoints.waypoints.transform.childCount - 1) {
				Destroy(gameObject);
			} else {
				wpIndex++;
				target = CreateWaypoints.waypoints.transform.GetChild(wpIndex).transform;
				print("switch wp: " + wpIndex);
			}
	}
}
