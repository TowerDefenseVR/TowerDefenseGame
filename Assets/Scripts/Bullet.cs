using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float velocity = 5.0f;
	private Transform target;

	public void SetTarget(Transform target) {
		this.target = target;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject != null && target != null) {
			transform.position = Vector3.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
		} else if(target == null) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Enemy") {
			if(gameObject != null) {
				Destroy(gameObject);
			}
		}
	}
}
