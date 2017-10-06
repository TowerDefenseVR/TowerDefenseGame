using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaypoints : MonoBehaviour {

	public static GameObject waypoints;	

	static void GenerateWaypoints() {
		for(int i = 0; i < CreateGrid.pathTiles.transform.childCount; i++) {
			GameObject waypoint = new GameObject("wp_" + i);
			waypoint.transform.parent = waypoints.transform;
			//waypoint.transform.position = GetWaypointPos(CreateGrid.pathTiles.transform.GetChild(i)).position;
		}
	}

	static Transform FindClosestPath(Transform[] pathTiles, Transform currentTile) {
	    Transform closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = currentTile.position;
        foreach (Transform path in pathTiles) {
            Vector3 diff = path.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
				print(distance);
                closest = path;
                distance = curDistance;
            }
        }
		print("FOUND: " + distance);
        return closest;
	}

	static List<Transform> GetWaypointList  (Transform currPath) {
		List<Transform> wpList = new List<Transform>();
		for(int i = 0; i < CreateGrid.pathTiles.transform.childCount; i++) {
			
		}
		return wpList;
	}

	static bool IsAdjacent(Transform currTile, Transform nextTile) {
		if(Mathf.Abs(currTile.position.x - nextTile.position.x) == 11 || Mathf.Abs(currTile.position.y - nextTile.position.x) == 11) {
			return true;
		} else {
			return false;
		}
	}


	// Use this for initialization
	public static void Start () {
		waypoints = new GameObject("Waypoints");
		GenerateWaypoints();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
