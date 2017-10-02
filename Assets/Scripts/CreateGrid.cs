using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {
	public int height;
	public int width;
	public int spaceBetween;

	// Use this for initialization
	void Start () {
		createMap();
	}

	void createMap() {
		ArrayList tiles = new ArrayList();
		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
				tile.name = "Tile" + i + "_" + j;
				tile.transform.position = new Vector3(i*(10+spaceBetween), 0, j*(10+spaceBetween));
				tiles.Add(tile);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
