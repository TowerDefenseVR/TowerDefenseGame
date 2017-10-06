using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CreateGrid : EditorWindow {
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
	private GameObject startTiles;
	private GameObject endTiles;


[MenuItem("Example/Test")]
    static void Init()
    {
        CreateGrid window = (CreateGrid)EditorWindow.GetWindowWithRect(typeof(CreateGrid), new Rect(0, 0, 200, 50));
        window.Show();
    }
	// Use this for initialization
	void OnGUI () {
		//CreateParents();
		//CreateMapFromImg(Directory.GetCurrentDirectory() + "/Assets/maps/map_test2.png");	
		if(GUILayout.Button("SaveScene")) {
			SaveSceneFromImg("/Assets/maps/map_test2.png", 1);
		}
		
	}

	void CreateParents() {
		game = new GameObject("Game");
		pathTiles = new GameObject("Path Tiles");
		groundTiles = new GameObject("Ground Tiles");
		unknownTiles = new GameObject("Unknown Tiles");
		startTiles = new GameObject("Start Tiles");
		endTiles = new GameObject("End Tiles");
	}

	public static Texture2D LoadPNG(string filePath) {
		Texture2D tex = null;
		byte[] fileData;
		if (File.Exists(filePath))     {
			 Debug.Log("loaded image");
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

	void SaveSceneFromImg(string pathImg, int level) {
		Scene scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Additive);
		Debug.Log("Scene Loaded" + (scene.isLoaded ? "OK" : "Error!"));
		SceneManager.SetActiveScene(scene);
		string[] path = EditorSceneManager.GetActiveScene().path.Split(char.Parse("/"));
		path[path.Length - 1] = "Assets/ScenesFromImg/Level_" + path[path.Length - 1];
		CreateParents();
		CreateMapFromImg(Directory.GetCurrentDirectory() + pathImg);
		bool saveOK = EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), string.Join("/", path) + ".unity");
		Debug.Log("Saved Scene " + (saveOK ? "OK" : "Error!"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
