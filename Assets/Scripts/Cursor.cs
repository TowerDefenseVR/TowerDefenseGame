using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {
	GameObject cube;
	public Material pathMaterial;
	public Material placeMaterial;


	// Use this for initialization
	void Start () {
		cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Destroy(cube.GetComponent<BoxCollider>());
	}
	
	// Update is called once per frame
	public void Update()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		// Casts the ray and get the first game object hit
		Physics.Raycast(ray, out hit);

		cube.transform.position = new Vector3(hit.point.x, cube.transform.lossyScale.y/2, hit.point.z);
		cube.GetComponent<MeshRenderer>().material = pathMaterial;

		if(Input.GetButtonDown("Fire1")){
			Debug.Log("FIRE");
			GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			newCube.transform.position = cube.transform.position;
			newCube.GetComponent<MeshRenderer>().material = placeMaterial;
		}

    }
}
