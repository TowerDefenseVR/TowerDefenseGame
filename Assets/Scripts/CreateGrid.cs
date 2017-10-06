using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateGrid : MonoBehaviour {
	public int spaceBetween;
	public Material pathMaterial;
	public Material groundMaterial;
	public Material startMaterial;
	public Material endMaterial;
	public Material unknownMaterial;

	//Remove when putting thing in own file
	public Material enemyMaterial;
	public static GameObject game;
	public static GameObject pathTiles;
	private GameObject groundTiles;
	public static GameObject startTiles;
	private GameObject endTiles;
	private GameObject unknownTiles;


	// Use this for initialization
	void Start () {
		//createMap();
		CreateParentObj();
		CreateMapFromImg(Directory.GetCurrentDirectory() + "/Assets/maps/map_test2.png");
		CreateWaypoints.Start();
	}

	public void CreateParentObj() {
		game = new GameObject("Game");
		pathTiles = new GameObject("Path Tiles");
		groundTiles = new GameObject("Ground Tiles");
		startTiles = new GameObject("Start Tiles");
		endTiles = new GameObject("End Tiles");
		unknownTiles = new GameObject("Unknown Tiles");
	}

	public static Texture2D LoadPNG(string filePath) {
		Texture2D tex = null;
		byte[] fileData;
		if (File.Exists(filePath))     {
			print("loaded image");
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(1,1);
			tex.LoadImage(fileData);
		}
		return tex;
	}

	void CreateMapFromImg(string path) {
		Texture2D tex = LoadPNG(path);
		Color pixel_colour = Color.clear;
		for(int i = 0; i < tex.width; i++) {
			for(int j = 0; j < tex.height; j++) {
				pixel_colour = tex.GetPixel(i,j);
				if(pixel_colour == Color.black) {
					GenerateTile("Path", pathTiles.transform, pathMaterial, i, j);
				} else if(pixel_colour == Color.green) {
					GenerateTile("Ground", groundTiles.transform, groundMaterial, i, j);
				} else if(pixel_colour == Color.blue) {
					GenerateTile("Start", startTiles.transform, startMaterial, i, j);

					//TODO: fix own file to create and handle enemies
					GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					enemy.name = "Enemy";
					enemy.transform.parent = game.transform;
					enemy.transform.position = new Vector3(i*(10+spaceBetween), 2, j*(10+spaceBetween));
					enemy.transform.localScale = new Vector3(4f, 4f, 4f);
					//enemy.AddComponent<EnemyMovement>();
					enemy.GetComponent<MeshRenderer>().material = enemyMaterial;
				} else if(pixel_colour == Color.red) {
					GenerateTile("End", endTiles.transform, endMaterial, i, j);
				} else {
					GenerateTile("Unknown", unknownTiles.transform, unknownMaterial, i, j);
				}
			}
		}	
	}
	
	void GenerateTile(string name, Transform parentOfObj, Material mat, int i, int j) {
		GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
		parentOfObj.transform.parent = game.transform;
		tile.transform.parent = parentOfObj;
		tile.name = name + "_" + i + ":" + j;
		tile.transform.position = new Vector3(i*(10+spaceBetween), 0, j*(10+spaceBetween));
		tile.GetComponent<MeshRenderer>().material = mat;
		tile.AddComponent<BoxCollider>();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
