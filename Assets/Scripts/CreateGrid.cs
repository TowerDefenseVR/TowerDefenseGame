using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateGrid : MonoBehaviour {
	public int height;
	public int width;
	public int spaceBetween;
	public Material pathMaterial;
	public Material groundMaterial;
	public Material startMaterial;
	public Material endMaterial;
	public Material unknownMaterial;
	private GameObject game;
	private GameObject pathTiles;
	private GameObject groundTiles;
	private GameObject unknownTiles;

	// Use this for initialization
	void Start () {
		//createMap();
		game = new GameObject("Game");
		pathTiles = new GameObject("Path Tiles");
		groundTiles = new GameObject("Ground Tiles");
		unknownTiles = new GameObject("Unknown Tiles");
		createMapFromImg(Directory.GetCurrentDirectory() + "/Assets/maps/map_test3.png");	
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

	void createMapFromImg(string path) {
		Texture2D tex = LoadPNG(path);
		Color pixel_colour = Color.clear;
		for(int i = 0; i < tex.width; i++) {
			for(int j = 0; j < tex.height; j++) {
				pixel_colour = tex.GetPixel(i,j);
				if(pixel_colour == Color.black) {
					GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
					tile.transform.parent = pathTiles.transform;
					pathTiles.transform.parent = game.transform;
					tile.name = "Path_" + i + ":" + j;
					tile.transform.position = new Vector3(i*(10+spaceBetween), 0, j*(10+spaceBetween));
					tile.GetComponent<MeshRenderer>().material = pathMaterial;
				} else if(pixel_colour == Color.green) {
					GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
					tile.transform.parent = groundTiles.transform;
					groundTiles.transform.parent = game.transform;
					tile.name = "Ground_" + i + ":" + j;
					tile.transform.position = new Vector3(i*(10+spaceBetween), 0, j*(10+spaceBetween));
					tile.GetComponent<MeshRenderer>().material = groundMaterial;
				} else if(pixel_colour == Color.blue) {
					GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
					tile.transform.parent = game.transform;
					tile.name = "Start_" + i + ":" + j;
					tile.transform.position = new Vector3(i*(10+spaceBetween), 0, j*(10+spaceBetween));
					tile.GetComponent<MeshRenderer>().material = startMaterial;
				} else if(pixel_colour == Color.red) {
					GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
					tile.transform.parent = game.transform;
					tile.name = "End_" + i + ":" + j;
					tile.transform.position = new Vector3(i*(10+spaceBetween), 0, j*(10+spaceBetween));
					tile.GetComponent<MeshRenderer>().material = endMaterial;
				} else {
					GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
					tile.transform.parent = unknownTiles.transform;
					unknownTiles.transform.parent = game.transform;
					tile.name = "Unknown_" + i + ":" + j;
					tile.transform.position = new Vector3(i*(10+spaceBetween), 0, j*(10+spaceBetween));
					tile.GetComponent<MeshRenderer>().material = unknownMaterial;
				}
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
