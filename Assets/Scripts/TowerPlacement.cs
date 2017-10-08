using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour {
	public Transform towerPrefab;
	public float radiusBetween;


	// Use this for initialization
	void Start () {
		towerPrefab = Instantiate(towerPrefab, towerPrefab.position, towerPrefab.rotation, GameObject.Find("Towers").transform);
	}
	
	// Update is called once per frame
	public void Update() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		// Casts the ray and get the first game object hit
		Physics.Raycast(ray, out hit);
		towerPrefab.position = new Vector3(hit.point.x, (hit.point.y+towerPrefab.lossyScale.y/2), hit.point.z);
		if(Input.GetButtonDown("Fire1") && Physics.OverlapSphere(towerPrefab.position, radiusBetween, 1 << LayerMask.NameToLayer("Ignore Raycast")).Length <= 1){
			Instantiate(towerPrefab, towerPrefab.position, towerPrefab.rotation, GameObject.Find("Towers").transform);
		} else if(Input.GetButtonDown("Fire1") && Physics.OverlapSphere(towerPrefab.position, radiusBetween, 1 << LayerMask.NameToLayer("Ignore Raycast")).Length > 1) {
			print("TOO CLOSE TO ANOTHER TOWER");
		}
    }
}
