using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float moveSpeed = 10f;
	public float turnSpeed = 10f;

	//move this to enemy stats script?
	private float health = 15.0f;
	private Transform target;
	private int wpIndex = 0;

	// Use this for initialization
	void Start () {
		target = Waypoints.waypoints[wpIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0) {
			Destroy(gameObject);
		}
		
		if(target.position != transform.position) {
			Quaternion rDir = Quaternion.LookRotation(target.position - transform.position);
			transform.position = Vector3.MoveTowards(transform.position, target.position,  Time.deltaTime * moveSpeed);
			transform.rotation = Quaternion.Slerp(transform.rotation, rDir, Time.deltaTime * turnSpeed);
		}
		
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

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet") {
			health -= collision.gameObject.GetComponent<Bullet>().damage;
		}
    }
}
