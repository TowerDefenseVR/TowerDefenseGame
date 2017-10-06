using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour {
	public Transform towerPrefab;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void Update() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		// Casts the ray and get the first game object hit
		Physics.Raycast(ray, out hit);

		towerPrefab.position = new Vector3(hit.point.x, (hit.point.y+towerPrefab.lossyScale.y/2), hit.point.z);

		if(Input.GetButtonDown("Fire1")){
			Instantiate(towerPrefab, towerPrefab.position, towerPrefab.rotation, GameObject.Find("Towers").transform);
		}

    }
}
