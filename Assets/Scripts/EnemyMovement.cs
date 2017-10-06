using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float moveSpeed = 7f;
	public float turnSpeed = 10f;
	private Transform target;
	private int wpIndex = 0;

	// Use this for initialization
	void Start () {
		target = Waypoints.waypoints[wpIndex];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mDir = target.position - transform.position;
		Quaternion rDir = Quaternion.LookRotation(target.position - transform.position);
		transform.Translate(mDir.normalized * moveSpeed * Time.deltaTime, Space.World);
		transform.rotation = Quaternion.Slerp(transform.rotation, rDir, Time.deltaTime * turnSpeed);
		if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
			NextWaypoint();
		}
	}

	void NextWaypoint() {
		if(wpIndex >= Waypoints.waypoints.Count - 1) {
			Destroy(gameObject);
		} else {
			wpIndex++;
			target = Waypoints.waypoints[wpIndex];
		}
	}
}
