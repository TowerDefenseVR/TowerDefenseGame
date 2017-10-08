using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : MonoBehaviour {
	public Transform bulletPrefab;
	public float fireRate;
	public float range;
	private Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		target = FindNearestEnemy();
		if(target != null) {
			RotateTowardEnemy();
			if(Vector3.Distance(transform.position, target.position) <= range && !IsInvoking("Fire")) {
				print("FIRE!");
				InvokeRepeating("Fire", 0.0f, 1/fireRate);
			} else if(Vector3.Distance(transform.position, target.position) > range && IsInvoking("Fire")) {
				print("HALT FIRE!");
				CancelInvoke("Fire");
			}
		}
	}

	void RotateTowardEnemy() {
		Vector3 targetDir = target.position - transform.position;
        float step = 10 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
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
		bulletPrefab = Instantiate(bulletPrefab, transform.position, transform.rotation);
		bulletPrefab.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 50));
	}
}
