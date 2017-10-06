﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

	public static List<Transform> waypoints = new List<Transform>();
	
	void Awake() {
		for(int i = 0; i < transform.childCount; i++) {
			waypoints.Add(transform.GetChild(i));
		}
	}

}
