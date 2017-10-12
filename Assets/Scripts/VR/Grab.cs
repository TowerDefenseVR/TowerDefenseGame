using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

	bool isHolding = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider c) {
		if (VRController.IsTrigged && !isHolding) {
			print("Holding " + c.gameObject.name);
			c.gameObject.transform.parent = gameObject.transform;
			c.gameObject.GetComponent<Rigidbody>().useGravity = false;
			c.gameObject.GetComponent<BoxCollider>().enabled = false;
			isHolding = true;
		}
		print("fuck");
	}
}
