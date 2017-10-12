using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VRController : MonoBehaviour {

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device controller {
         get { return SteamVR_Controller.Input((int)trackedObject.index); }
    }


	public static bool IsTrigged = false;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if ( controller.GetHairTrigger()){
            IsTrigged = true;
        } else {
			IsTrigged = false;
		}
	}

}
