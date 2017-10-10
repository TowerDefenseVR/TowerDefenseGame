using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : MonoBehaviour {
	public Transform bulletPrefab;
	public float fireRate;
	public float fireRange;
	public float rotSpeed;
	private Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		target = FindNearestEnemy();
		if(target != null) {
			RotateTowardEnemy();
			if(Vector3.Distance(transform.position, target.position) <= fireRange && !IsInvoking("Fire")) {
				InvokeRepeating("Fire", 0.0f, 1/fireRate);
			} else if(Vector3.Distance(transform.position, target.position) > fireRange && IsInvoking("Fire")) {
				CancelInvoke("Fire");
			}
		}
	}

	void RotateTowardEnemy() {
		//Transform barrel = transform.Find("Barrel");
		Vector3 targetDir = target.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed * Time.deltaTime, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}

	Transform FindNearestEnemy() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Transform closest = null;
		float dist = Mathf.Infinity;
        Vector3 pos = transform.position;
		foreach(GameObject enemy in enemies) {
			Vector3 diff = enemy.transform.position - pos;
            float curDist = diff.sqrMagnitude;
            if (curDist < dist) {
                closest = enemy.transform;
                dist = curDist;
            }
        }
        return closest;
	}

	void Fire() {
		Transform bulletClone = Instantiate(bulletPrefab, transform.Find("Barrel").position, transform.Find("Barrel").rotation);
		Bullet b = bulletClone.GetComponent<Bullet>();
		if(b != null) {
			b.SetTarget(target);
		}
		//bulletClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 20));
		//bulletPrefab.Translate(Vector3.forward * Time.deltaTime, Space.World);
		//bulletClone.position = Vector3.MoveTowards(transform.position, target.position, .003f);
	}
}
